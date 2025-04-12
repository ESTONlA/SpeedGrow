using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using MelonLoader;
using ScheduleOne.Growing;
using UnityEngine;

namespace PlantMod;

public class PlantMod : MelonMod
{
	[CompilerGenerated]
	private sealed class _003CChangeGrowthTimeAfterDelay_003Ed__2 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlantMod _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CChangeGrowthTimeAfterDelay_003Ed__2(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = (object)new WaitForSeconds(10f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E4__this.ChangeGrowthTime();
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[CompilerGenerated]
	private sealed class _003CRegularGrowthTimeCheck_003Ed__3 : IEnumerator<object>, IDisposable, IEnumerator
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlantMod _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CRegularGrowthTimeCheck_003Ed__3(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Expected O, but got Unknown
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				break;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E4__this.ChangeGrowthTime();
				break;
			}
			_003C_003E2__current = (object)new WaitForSeconds(5f);
			_003C_003E1__state = 1;
			return true;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private const int NewGrowthTime = 1;

	public override void OnApplicationStart()
	{
		MelonLogger.Msg("Plant Growth Mod Loaded!");
		MelonCoroutines.Start(ChangeGrowthTimeAfterDelay());
		MelonCoroutines.Start(RegularGrowthTimeCheck());
	}

	[IteratorStateMachine(typeof(_003CChangeGrowthTimeAfterDelay_003Ed__2))]
	private IEnumerator ChangeGrowthTimeAfterDelay()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CChangeGrowthTimeAfterDelay_003Ed__2(0)
		{
			_003C_003E4__this = this
		};
	}

	[IteratorStateMachine(typeof(_003CRegularGrowthTimeCheck_003Ed__3))]
	private IEnumerator RegularGrowthTimeCheck()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CRegularGrowthTimeCheck_003Ed__3(0)
		{
			_003C_003E4__this = this
		};
	}

	private void ChangeGrowthTime()
	{
		try
		{
			Type type = Type.GetType("ScheduleOne.Growing.Plant, Assembly-CSharp");
			if (type != null)
			{
				FieldInfo field = type.GetField("GrowthTime", BindingFlags.Instance | BindingFlags.Public);
				if (field != null)
				{
					Plant[] array = Object.FindObjectsOfType<Plant>(true);
					Plant[] array2 = array;
					foreach (Plant obj in array2)
					{
						field.SetValue(obj, 1);
					}
				}
				else
				{
					MelonLogger.Error("GrowthTime field not found.");
				}
			}
			else
			{
				MelonLogger.Error("Plant class not found.");
			}
		}
		catch (Exception ex)
		{
			MelonLogger.Error("Error changing GrowthTime: " + ex.Message);
		}
	}
}
