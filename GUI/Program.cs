using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using SharpSvn;
using Deployer.Repo;

namespace Deployer
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//// setup logging
			//var logFileName = "DistroMaker.log";
			//if (!String.IsNullOrEmpty(logFileName))
			//{
			//	var target = (NLog.Targets.FileTarget)NLog.LogManager.Configuration.FindTargetByName("logfile");
			//	target.FileName = logFileName;
			//	NLog.LogManager.ReconfigExistingLoggers();
			//}

			//Test1();
			//Test2();
			//Test3();
			//Test4();
			//Test5();
			//Test6();
			//Test7();
			Test8();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FrmMain());
		}

		//static void Test1()
		//{
		//	var cwd = System.IO.Directory.GetCurrentDirectory();
		//	using (Lua lua = new Lua())
		//	{
		//		lua.State.Encoding = Encoding.UTF8;
		//		//lua.DoString("Externals={{Path='Bin', Name='All', URL='myUrl/blabla' }} res = 'Файл'");
		//		lua.DoFile("Config/Templates/IG/externals.lua");
		//		//string res = (string)lua["res"];
		//		var exts = lua["Externals"] as LuaTable;
		//		foreach( LuaTable ext in exts.Values )
		//		{
		//			var path = (string)ext["Path"];
		//			var name = (string)ext["Name"];
		//			var unknown = (string)ext["unknown"];
		//		}
		//		//int i = 1;
		//	}			
		//}

		static void Test2()
		{
			var client = new SvnClient();
			string val;
			var result = client.GetProperty( new SvnUriTarget("file:///D:/Work/svn/BIST/repo/releases/IG/Head/Config"), "svn:externals", out val );
			if(!result) return;
            SvnExternalItem[] items;
            result = SvnExternalItem.TryParse( val, out items);

		}

		static void Test3()
		{
			var client = new SvnClient();
			ExtDefList exList = new ExtDefList();
			exList.Externals.Add( new ExtDef() { LocalPath="Config", Target="Base", BaseUrl="^/shared/IG/Config/Base/trunk2" } );
			exList.Install(
				client,
				"file:///D:/Work/svn/BIST/repo/releases/IG/Head",
				new ExtDef.InstCmd() { Mode=ExtDef.EInstallMode.Head }
			);
		}

		static void Test4()
		{
			var client = new SvnClient();
			Collection<SvnListEventArgs> list;
			SvnListArgs args = new SvnListArgs();
			args.Depth = SvnDepth.Infinity;
			if( client.GetList( new SvnUriTarget( "file:///D:/Work/svn/BIST/repo/releases" ), args, out list ) )
			{
			}
		}
		
		static void Test5()
		{
			var client = new SvnClient();
			{
				List<string> modules;
				var rootUrl = "file:///D:/Work/svn/BIST/repo/installs";
				if( ModuleScanner.Scan( client, rootUrl, out modules ) )
				{
				}
			}

			{
				List<string> installs;
				var rootUrl = "file:///D:/Work/svn/BIST/repo/releases";
				if( InstallScanner.Scan( client, rootUrl, out installs ) )
				{
				}
			}
			
			{
				List<string> templates;
				var rootUrl = "file:///D:/Work/svn/BIST/repo/templates";
				if( TemplateScanner.Scan( client, rootUrl, out templates ) )
				{
					foreach( var t in templates )
					{
						string templateUrl = $"{rootUrl}/{t}";
						ExtDefList extDefs;
						if( TemplateScanner.GetExtDefs( client, templateUrl, out extDefs ) )
						{
						} 
					}
				}
			}
		}
		static void Test6()
		{
			var client = new SvnClient();
			var url = "file:///D:/Work/svn/BIST/repo/releases/IG/Head/Config";
			SvnInfoEventArgs info;
			if( !client.GetInfo( new Uri(url), out info) )
				return;
		}
			
		static void Test7()
		{
			var client = new SvnClient();
			string val;
			var hostUrl = "file:///D:/Work/svn/BIST/repo/releases/IG/Head";
			var result = client.GetProperty( new SvnUriTarget(hostUrl), "svn:externals", out val );
			if(!result) return;
            SvnExternalItem[] items;
            result = SvnExternalItem.TryParse( val, out items);

			//var uriTarget = new SvnUriTarget( url );
			//var uri = new Uri(url);
			//uri.

						
			//ReleaseMaker.GetFullReferenceUrl(client, items[0], hostUrl);
		}

		static void Test8()
		{
			var client = new SvnClient();
			var baseUrl = "file:///D:/Work/svn/BIST/repo/releases/IG";
			//var srcUrl = $"{baseUrl}/Head";
			//var releaseName = "candidate/3.0.1";
			//var destUrl = $"{baseUrl}/{releaseName}";
			//var res = ReleaseMaker.Copy( client, srcUrl, destUrl, ReleaseMaker.EPinType.Branch, releaseName );

			//var srcUrl = $"{baseUrl}/Head";
			//var releaseName = "candidate/3.0.2";
			//var destUrl = $"{baseUrl}/{releaseName}";
			//var res = ReleaseMaker.Copy( client, srcUrl, destUrl, ReleaseMaker.EPinType.Peg, releaseName );

			var srcUrl = $"{baseUrl}/candidate/3.0.2";
			var releaseName = "candidate/3.0.3";
			var destUrl = $"{baseUrl}/{releaseName}";
			var res = ReleaseMaker.Copy( client, srcUrl, destUrl, ReleaseMaker.EPinType.Tag, releaseName );
		}

	}
}
