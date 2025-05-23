using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentPlayground
{
    public class MenuGridLayoutManager : GridLayoutManager
    {
        MenuGridLayout _menuGrid;
        public MenuGridLayoutManager(MenuGridLayout menuGrid):base(menuGrid)
        {
            _menuGrid = menuGrid;
        }
        public override Size Measure(double widthConstraint, double heightConstraint)
        {
            return base.Measure(widthConstraint, heightConstraint);
        }

        public override Size ArrangeChildren(Rect bounds)
        {
            var padding = Grid.Padding;
            double top = padding.Top + bounds.Top;
            double bottom = padding.Bottom + bounds.Bottom;
            double left = padding.Left + bounds.Left;
            double right = padding.Right + bounds.Right;
            return base.ArrangeChildren(bounds);
        }
        private void AssembleMenu()
        {
            //Figure out correct check here
        }
    }
}
