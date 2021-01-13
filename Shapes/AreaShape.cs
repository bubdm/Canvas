using Chart.ModelSpace;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Chart.ShapeSpace
{
  public class AreaShape : BaseShape, IShape
  {
    /// <summary>
    /// Render the shape
    /// </summary>
    /// <param name="position"></param>
    /// <param name="series"></param>
    /// <param name="items"></param>
    /// <returns></returns>
    public override void CreateShape(int position, string series, IList<IPointModel> items)
    {
      var currentItem = items.ElementAtOrDefault(position);
      var previousItem = items.ElementAtOrDefault(position - 1);

      if (currentItem == null || previousItem == null)
      {
        return;
      }

      var currentModel = currentItem.Areas[Composer.Name].Series[series].Model;
      var previousModel = previousItem.Areas[Composer.Name].Series[series].Model;

      var shapeModel = new ShapeModel
      {
        Size = 1,
        Color = Brushes.Black.Color
      };

      var points = new Point[]
      {
        Composer.GetPixels(Panel, position - 1, previousModel.Point),
        Composer.GetPixels(Panel, position, currentModel.Point),
        Composer.GetPixels(Panel, position, Composer.MinValue),
        Composer.GetPixels(Panel, position - 1, Composer.MinValue),
        Composer.GetPixels(Panel, position - 1, previousModel.Point)
      };

      Panel.CreateShape(points, shapeModel);
    }
  }
}
