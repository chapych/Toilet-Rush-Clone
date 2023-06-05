using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "MenuInstallerForSO", menuName = "Installers/MenuInstallerForSO")]
public class MenuInstallerForSO : ScriptableObjectInstaller<MenuInstallerForSO>
{
	[SerializeField] private MenuTransition menuTransition;
	public override void InstallBindings()
	{
		Container.Bind<MenuTransition>()
				 .FromInstance(menuTransition);
	}
}