using System;
using UnityEngine;


	[Serializable]
	public class Damageable
	{

		public float maxHealth;		
		public float startingHealth;
		public float currentHealth { protected set; get; }
		public float normalisedHealth
		{
			get
			{
				if (Math.Abs(maxHealth) <= Mathf.Epsilon)
				{
					Debug.LogError("Max Health is 0");
					maxHealth = 1f;
				}
				return currentHealth / maxHealth;
			}
		}

		public bool isDead
		{
			get { return currentHealth <= 0f; }
		}


		public bool isAtMaxHealth
		{
			get { return Mathf.Approximately(currentHealth, maxHealth); }
		}

		public event Action reachedMaxHealth;

		public event Action<HealthChangeInfo> damaged, healed, died, healthChanged;


		public virtual void Init()
		{
			currentHealth = startingHealth;
		}


		public void SetMaxHealth(float health)
		{
			if (health <= 0)
			{
				return;
			}
			maxHealth = startingHealth = health;
		}


		public void SetHealth(float health)
		{
			var info = new HealthChangeInfo
			{
				damageable = this,
				newHealth = health, 
				oldHealth = currentHealth
			};
			
			currentHealth = health;
			
			if (healthChanged != null)
			{
				healthChanged(info);
			}
		}


		public bool TakeDamage(float damage, IAlignmentProvider damageAlignment, out HealthChangeInfo output)
		{
			output = new HealthChangeInfo
			{
				damageAlignment = damageAlignment, damageable = this,
				newHealth = currentHealth, oldHealth = currentHealth
			};
			
			bool canDamage = damageAlignment == null || alignmentProvider == null ||
			                 damageAlignment.CanHarm(alignmentProvider);
			
			if (isDead || !canDamage)
			{
				return false;
			}

			ChangeHealth(-damage, output);
			SafelyDoAction(damaged, output);
			if (isDead)
			{
				SafelyDoAction(died, output);
			}
			return true;
		}

		/// <summary>
		/// Logic for increasing the health.
		/// </summary>
		/// <param name="health">Health.</param>
		public HealthChangeInfo IncreaseHealth(float health)
		{
			var info = new HealthChangeInfo {damageable = this};
			ChangeHealth(health, info);
			SafelyDoAction(healed, info);
			if (isAtMaxHealth)
			{
				SafelyDoAction(reachedMaxHealth);
			}

			return info;
		}

		/// <summary>
		/// Changes the health.
		/// </summary>
		/// <param name="healthIncrement">Health increment.</param>
		/// <param name="info">HealthChangeInfo for this change</param>
		protected void ChangeHealth(float healthIncrement, HealthChangeInfo info)
		{
			info.oldHealth = currentHealth;
			currentHealth += healthIncrement;
			currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
			info.newHealth = currentHealth;
			
			if (healthChanged != null)
			{
				healthChanged(info);
			}
		}

		/// <summary>
		/// A helper method for null checking actions
		/// </summary>
		/// <param name="action">Action to be done</param>
		protected void SafelyDoAction(Action action)
		{
			if (action != null)
			{
				action();
			}
		}

		/// <summary>
		/// A helper method for null checking actions
		/// </summary>
		/// <param name="action">Action to be done</param>
		/// <param name="info">The HealthChangeInfo to be passed to the Action</param>
		protected void SafelyDoAction(Action<HealthChangeInfo> action, HealthChangeInfo info)
		{
			if (action != null)
			{
				action(info);
			}
		}
	}
