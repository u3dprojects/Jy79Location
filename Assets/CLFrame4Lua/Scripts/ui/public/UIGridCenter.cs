using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UIGrid))]
public class UIGridCenter : MonoBehaviour {
	UIGrid _grid;
	public UIGrid grid{
		get {
			if(_grid == null) {
				_grid = gameObject.GetComponent<UIGrid>();
			}
			return _grid;
		}
	}

	[ContextMenu("Execute -Hor")]
	public void setCenterH() {
		setCenter(false);
	}
	
	[ContextMenu("Execute -Both")]
	public void setCenterBoth() {
		setCenter(true);
	}
	public void setCenter(bool useWidgeBounds, bool isBooth = false) {
		Vector3 v3 = grid.transform.localPosition;
		float w = 0, h = 0;
		if (useWidgeBounds) {
			Bounds b = NGUIMath.CalculateRelativeWidgetBounds(grid.transform, false);
			w = b.size.x;
			h = b.size.y;
		} else {
			int count  = getActiveCellCount();
			w = (count < grid.maxPerLine || grid.maxPerLine <= 0) ? count : grid.maxPerLine;
			w = w*grid.cellWidth;
			h = Mathf.CeilToInt (((float)count)/((float)(grid.maxPerLine)))*grid.cellHeight;
		}
		float x = -(w - grid.cellWidth) / 2.0f;
		float y = v3.y;
		if (isBooth) {
			y = (h - grid.cellHeight) / 2.0f;
		}
		v3.x = x;
		v3.y = y;
		grid.transform.localPosition = v3;
	}

	public int getActiveCellCount()
	{
		int ret = 0;
		for(int i=0; i < grid.transform.childCount; i++) {
			if(grid.transform.GetChild(i).gameObject.activeSelf) {
				ret++;
			}
		}
		return ret;
	}
}
