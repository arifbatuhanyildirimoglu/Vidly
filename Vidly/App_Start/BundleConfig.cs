﻿using System.Web.Optimization;

namespace Vidly
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new Bundle("~/bundles/lib").Include(
									"~/Scripts/jquery-{version}.js",
									"~/Scripts/bootbox.js",
									"~/Scripts/bootstrap.js",
									"~/Scripts/respond.js",
									"~/Scripts/datatables/jquery.datatables.js",
									"~/Scripts/datatables/datatables.bootstrap4.js",
									"~/scripts/typeahead.bundle.js",
									"~/scripts/toastr.js"
									));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
									"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
									"~/Scripts/modernizr-*"));
			//bundles.Add(new Bundle("~/bundles/bootstrap").Include(
			//"~/Scripts/bootstrap.js"));


			bundles.Add(new StyleBundle("~/Content/css").Include(
								"~/Content/bootstrap-lumen.css",
								"~/Content/datatables/css/datatables.bootstrap.css",
								"~/Content/typeahead.css",
								"~/Content/toastr.css",
								"~/Content/site.css"
								));
		}
	}
}
