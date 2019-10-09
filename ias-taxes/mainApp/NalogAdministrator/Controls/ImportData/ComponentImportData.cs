using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace NalogAdministrator.Controls.ImportData
{
    public partial class ComponentImportData : Component
    {
        public ComponentImportData()
        {
            InitializeComponent();
        }

        public ComponentImportData(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
