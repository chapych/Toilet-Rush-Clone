using Bindings;
using UnityEngine;
using Zenject;

namespace Infrastructure.Factories
{
	public class GameFactory
	{
		private readonly IAssetProvider assetProvider;


		public GameFactory(IAssetProvider assetProvider)
		{
			this.assetProvider = assetProvider;
		}
	
		public GameObject CreateLine(Vector2 at)
		{
			GameObject prefab = assetProvider.Get(AssetPath.LINE_PREFAB_PATH);
			return Object.Instantiate(prefab, at, Quaternion.identity);
		}
		

	}
}