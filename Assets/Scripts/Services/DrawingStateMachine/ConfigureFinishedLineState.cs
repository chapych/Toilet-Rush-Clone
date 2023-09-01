using Character;
using Drawing;
using UnityEngine;

namespace Services.DrawingStateMachine
{
	public class ConfigureFinishedLineState : IPayloadedEnteringState<ILineHolder>
	{
		private readonly IDrawingStateMachine context;
		private readonly ILineCreator creator;
		public ConfigureFinishedLineState(IDrawingStateMachine context, ILineCreator creator)
		{
			this.context = context;
			this.creator = creator;
		}
		public void Enter(ILineHolder holder)
		{
			{
				SetLineConfigures(holder);
				creator.CurrentLine = null;
			}
		}

		private void SetLineConfigures(ILineHolder holder)
		{
			ILine current = creator.CurrentLine;
			
			holder.Line = current;
			current.transform.parent = holder.transform;
		}

		public void Exit()
		{ }
	}
}