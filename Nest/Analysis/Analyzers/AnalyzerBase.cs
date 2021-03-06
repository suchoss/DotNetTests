// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Runtime.Serialization;
using Elasticsearch.Net.Utf8Json;

namespace Nest
{
	[JsonFormatter(typeof(AnalyzerFormatter))]
	public interface IAnalyzer
	{
		[DataMember(Name = "type")]
		string Type { get; }

		/// <summary>
		/// Setting a version on analysis component has no effect and is deprecated. 
		/// This setting will be removed in v8.0.
		/// </summary>
		[DataMember(Name = "version")]
		[Obsolete("Setting a version on analysis component has no effect and is deprecated.")]
		string Version { get; set; }
	}

	public abstract class AnalyzerBase : IAnalyzer
	{
		internal AnalyzerBase() { }

		// ReSharper disable once VirtualMemberCallInConstructor
		protected AnalyzerBase(string type) => Type = type;

		public virtual string Type { get; protected set; }

		/// <inheritdoc cref="IAnalyzer.Version" />
		[Obsolete("Setting a version on analysis component has no effect and is deprecated.")]
		public string Version { get; set; }
	}

	public abstract class AnalyzerDescriptorBase<TAnalyzer, TAnalyzerInterface>
		: DescriptorBase<TAnalyzer, TAnalyzerInterface>, IAnalyzer
		where TAnalyzer : AnalyzerDescriptorBase<TAnalyzer, TAnalyzerInterface>, TAnalyzerInterface
		where TAnalyzerInterface : class, IAnalyzer
	{
		protected abstract string Type { get; }
		string IAnalyzer.Type => Type;
		string IAnalyzer.Version { get; set; }

		/// <inheritdoc cref="IAnalyzer.Version" />
		[Obsolete("Setting a version on analysis component has no effect and is deprecated.")]
		public TAnalyzer Version(string version) => Assign(version, (a, v) => a.Version = v);
	}
}
