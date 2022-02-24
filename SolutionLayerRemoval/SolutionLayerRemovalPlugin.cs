using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace SolutionLayerRemoval
{
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Solution Layer Removal"),
        ExportMetadata("Description", "a Tool will allow you to remove all the unmanaged customization on top of a managed solution - Caution!!! don't run it in Sandbox instance"),
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAABHNCSVQICAgIfAhkiAAAAAFzUkdCAK7OHOkAAAAEZ0FNQQAAsY8L/GEFAAAACXBIWXMAAA7EAAAOxAGVKw4bAAAAGXRFWHRTb2Z0d2FyZQB3d3cuaW5rc2NhcGUub3Jnm+48GgAABTZJREFUWEe9VmtsFGUUPbO7szM7u2234CJCMIAPEIxtjSWNaLSBJhpNMD6ICT6BBImkQY3xV/3DL2OIhKBIAkRFogEBCb6S0hAjGJIGKdUioCIBgZYi3W53Z+exs+O9325t92F3Fo0n/TH7fXPvOfc5lVwCrgMXhy309Rvief5UFdPrguK5WlQt4OcBAz8RMZvJfkmc2Y4LSZJwJwm540ZVnHmFJwFO1sWJS2mcHjQR8EmQfWRIhOPBbuwskKF358QUNEwLwU/vVsKEApKmg+MX07gQtxGkaANliIvB7jIkxKKszIjKaJoeQkTx529LUVbAlREbPRTxnykHwYAEznQl4mKwW9IAK+NictiPRsrIlBo5fzuGAgHnrlmUah2GnauvlxR6AZeQ+0SVJSqNhpmTxhpWCDhJTdXXnwYrYWJfldF6RZZiFQ1Lz/OnhjCPmlY60Bd3dSsralxtmq8XnHTuEY262RcLB0Tn0t//BuZizlgkkCtBwnDQfV7HlWQGCjWdj2r/X+eC48sSqUlNOYWIm2/WUKv6C5uQx677go7LiQxUFkIq/m1Z2D1HbBDxTbVEPEMrGMuyY5imjdJ7ycBlGkcafaH+esDSaSVgKo1fwzQVId5gRSg9IfCLPsfCHwMJ6GYGAb+PMpG/9AB+l23Y9uKVBBRkypIzCjJg0Qo7ePIajp0jI1p7PJI8OjI9x6JUs7BCM52ltOYNisDEfp8PiZSJwbgOm/zxSFtOVozfgll1WDRvUsF+EQKujliC+Ex/CqGgXxCPrz1r5GXCUcXqNdSFg+L3qJAcsYThlIXBIR0ZIuTfxT5YRJpGft70MBaTkKgmQ9p7bMD98UISYcVXYlSMMSESbqCMRCOKOI8nTVyliDNE4MUHj2CKGv6emXWQ3us67w6nqeupRl47np3wSPkpIwyHIhajW4U9N/rkCGWAfrhHfonj29NDpB6i9tU4YlTzvkl9QXrxwJx6LLwtWtiER3+L49CpITE+Ck+CR8eVwI1sUsRM1Dq3Hi23RHMXhLJ74NSgg+/PJqEbJhzbZOn5mypBAfhlBZqq4N7ZEcyNlf5fUHY4Dx/4BDvefBG9XXvgD8gIqprnNDP4XbZhW/bBvthnOfydgaH4MN7ZtA37v+xETSSMUEgV0WcsE7e3tKFh0eMIBFXYBn22Xd5vpZAk2h1qiGwMnOjaizNHO8lGEVlIpw2MJFNY8kgbXlmzAvXRupxN/8Cg27FuPY52H0c0WgtVUQqiZX0swjbTuLW5FY2Ln0RQi5AQHS4tJYZEy0emiC09iZ6Dn+HX7kOQlZAgL/ZlmCbi8QRampuwruNVSAseXOKqShBKEXEx2NixLVhGCrOb7kdj21MI1daLu3RiCD2du3H2+HeU+jBFHKzoyyQhhmlB2r3vK3fdWxsRobRrWqhi548XMqtxoTj7veeIJ2IGT4Sup5GkcnS80T7WA5u3foytH34qMhFmIZTWicBm2Ywtnn3UbBWJqVwpIubIVz7/NFavfEacl4zh9h278P62nbTl/IiEtYpCKoGJkymdtqWDl1Ysw/Jnl+Zvcii7Bxg7d32OTVs+EpFyefgrVw34q8lp5sysWfUcli19LH9TiH8UMIo9+7/Ghne3w7JtMZ6cmYnAkfK4BWUZa19ejieWPJy/KY+KAkbxxTddWL9xK9VRR21NpEQIEydG6KuqaXitfSUefWhR/mZieBYwis5Dh/H2hi1icbEQBhPzYnl97Sq0td4nzryiagGj6P6hFxs3fyCe21e/gOa77xLP1QH4C81NqVXl80BQAAAAAElFTkSuQmCC"),
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class SolutionLayerRemovalPlugin : PluginBase,IPayPalPlugin
    {
        public string DonationDescription => "Donation for me on doing Solution Layers Removal";

        public string EmailAccount => "abod.h95@gmail.com";

        public override IXrmToolBoxPluginControl GetControl()
        {
            return new SolutionLayerRemovalControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public SolutionLayerRemovalPlugin()
        {
            
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}