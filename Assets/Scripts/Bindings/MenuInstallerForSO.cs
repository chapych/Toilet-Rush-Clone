using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "MenuInstallerForSO", menuName = "Installers/MenuInstallerForSO")]
public class MenuInstallerForSO : ScriptableObjectInstaller<MenuInstallerForSO>
{
	[SerializeField] private MenuTransition menuTransition;
	[SerializeField] private AudioPlayerSO player;
	public override void InstallBindings()
    {
        BindMenuTransition();
        BindAudioPlayer();
    }

    private void BindMenuTransition()
    {
        Container.Bind<MenuTransition>()
                 .FromInstance(menuTransition);
    }

    private void BindAudioPlayer()
    {
        Container.Bind<AudioPlayerSO>()
                 .FromInstance(player);
    }
}