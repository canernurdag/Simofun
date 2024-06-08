using Simofun.DevCaseStudy.Unity.Assets.TapDragToClean.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simofun.DevCaseStudy.Unity.Assets.TapDragToClean.Scripts.Controllers.CleanerController
{
	public class CleanerTextureManipulator : MonoBehaviour
	{
		[SerializeField] private Texture2D _greenUvLayout;
		[SerializeField] private Texture2D painterBrush;
		[SerializeField] private Material _material;


		private Texture2D _runtimeGreenUvLayout;
		private float _totalPixelCount;
		private float _dirtyPixelCount;


		private void Awake()
		{
			InitSessionGreenUvLayoutTexture();
		}

		private void OnEnable()
		{
			CleanGameplayEvents.OnRaycastHit += ManipulatePixels;
		}

		private void OnDisable()
		{
			CleanGameplayEvents.OnRaycastHit -= ManipulatePixels;
		}

		private void InitSessionGreenUvLayoutTexture()
		{
			//CREATE NEW GREEN UV LAYOUT TEXTURE2D from GREEN UV LAYOUT
			_runtimeGreenUvLayout = new Texture2D(_greenUvLayout.width, _greenUvLayout.height);

			//SET PIXELS from GREEN UV LAYOUT
			_runtimeGreenUvLayout.SetPixels(_greenUvLayout.GetPixels());
			_runtimeGreenUvLayout.Apply();

			//SET new GREEN UV LAYOUT Texture to the material
			_material.SetTexture("_DirtMask", _runtimeGreenUvLayout);

			_totalPixelCount = 0f;
			for (int x = 0; x < _greenUvLayout.width; x++)
			{
				for (int y = 0; y < _greenUvLayout.height; y++)
				{
					_totalPixelCount += _greenUvLayout.GetPixel(x, y).g;
				}
			}
			_dirtyPixelCount = _totalPixelCount;
		}

		private void ManipulatePixels(RaycastHit raycastHit)
		{
			//HIT TEXTURE COORD
			Vector2 textureCord = raycastHit.textureCoord;

			//HIT PIXEL
			int pixelX = (int)(textureCord.x * _runtimeGreenUvLayout.width);
			int pixelY = (int)(textureCord.y * _runtimeGreenUvLayout.height);

			//HIT PIXEL POSITION
			Vector2Int paintPixelPosition = new Vector2Int(pixelX, pixelY);


			int pixelXOffset = pixelX - painterBrush.width / 2;
			int pixelYOffset = pixelY - painterBrush.height / 2;

			for (int x = 0; x < painterBrush.width; x++)
			{
				for (int y = 0; y < painterBrush.height; y++)
				{

					Color pixelPainterBrush = painterBrush.GetPixel(x, y);
					Color pixelRuntimeGreenUvLayout = _runtimeGreenUvLayout.GetPixel(pixelXOffset + x, pixelYOffset + y);

					float removedAmount = pixelRuntimeGreenUvLayout.g - pixelRuntimeGreenUvLayout.g * pixelPainterBrush.g;
					_dirtyPixelCount -= removedAmount;

					_runtimeGreenUvLayout.SetPixel(
						pixelXOffset + x,
						pixelYOffset + y,
						new Color(0, pixelRuntimeGreenUvLayout.g * pixelPainterBrush.g, 0));
				}
			}

			_runtimeGreenUvLayout.Apply();

			CleanGameplayEvents.ExecuteOnTextureManipulationRationChanged(1f-GetDirtAmount());
		}

		private float GetDirtAmount()
		{
			return _dirtyPixelCount / _totalPixelCount;
		}
	}

}
