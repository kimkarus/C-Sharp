using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NalogUser.Forms
{
    public partial class ComponentViews : Component
    {
        public ComponentViews()
        {
            InitializeComponent();
        }

        public ComponentViews(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
