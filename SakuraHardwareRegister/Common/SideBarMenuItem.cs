using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SakuraHardwareRegister.Common
{
    public class SideBarMenuItem : HamburgerMenuIconItem
    {
        public SideBarMenuItem(string label, PackIconMaterialKind icon) 
        {
            Label = label;
            Icon = new PackIconMaterial
            {
                Kind = icon,
                Width = 28,
                Height = 28,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
        }
    }
}
