﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Threading.Tasks;
using ICSharpCode.Core;
using ICSharpCode.SharpDevelop.Gui;

namespace ICSharpCode.SharpDevelop.Project
{
	/// <summary>
	/// A project that is not a real project, but a MSBuild file included as project.
	/// </summary>
	public class MSBuildFileProject : AbstractProject
	{
		public MSBuildFileProject(FileName fileName, string title)
		{
			Name     = title;
			FileName = fileName;
			TypeGuid = "{00000000-0000-0000-0000-000000000000}";
		}
		
		public override Task<bool> BuildAsync(ProjectBuildOptions options, IBuildFeedbackSink feedbackSink, IProgressMonitor progressMonitor)
		{
			return MSBuildEngine.BuildAsync(this, options, feedbackSink, progressMonitor.CancellationToken, MSBuildEngine.AdditionalTargetFiles);
		}
	}
}
