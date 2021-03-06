// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using Elasticsearch.Net.Utf8Json;

namespace Nest
{
	/// <summary>
	/// An ip field can index/store either IPv4 or IPv6 addresses.
	/// </summary>
	[InterfaceDataContract]
	public interface IIpProperty : IDocValuesProperty
	{
		[Obsolete("The server always treated this as a noop and has been removed in 7.10")]
		[DataMember(Name ="boost")]
		double? Boost { get; set; }

		[DataMember(Name ="index")]
		bool? Index { get; set; }

		[DataMember(Name ="null_value")]
		string NullValue { get; set; }

		/// <summary>
		/// If <c>true</c>, malformed IP addresses are ignored. If <c>false</c> (default), malformed IP addresses throw an exception and reject the whole document.
		/// Note that this cannot be set if the script parameter is used.
		/// </summary>
		[DataMember(Name = "ignore_malformed")]
		bool? IgnoreMalformed { get; set; }

		/// <summary>
		/// If this parameter is set, then the field will index values generated by this script, rather than reading the values directly from the source.
		/// If a value is set for this field on the input document, then the document will be rejected with an error.
		/// Scripts are in the same format as their runtime equivalent. Scripts can only be configured on long and double field types.
		/// </summary>
		[DataMember(Name = "script")]
		IInlineScript Script { get; set; }

		/// <summary>
		/// Defines what to do if the script defined by the `script` parameter throws an error at indexing time.Accepts `reject` (default), which
		/// will cause the entire document to be rejected, and `ignore`, which will register the field in the document's ignored metadata field and
		/// continue indexing.This parameter can only be set if the `script` field is also set.
		/// </summary>
		[DataMember(Name = "on_script_error")]
		OnScriptError? OnScriptError { get; set; }
	}

	/// <inheritdoc cref="IIpProperty"/>
	[DebuggerDisplay("{DebugDisplay}")]
	public class IpProperty : DocValuesPropertyBase, IIpProperty
	{
		public IpProperty() : base(FieldType.Ip) { }

		public double? Boost { get; set; }
		public bool? Index { get; set; }
		public string NullValue { get; set; }

		/// <inheritdoc />
		public bool? IgnoreMalformed { get; set; }

		/// <inheritdoc />
		public IInlineScript Script { get; set; }

		/// <inheritdoc />
		public OnScriptError? OnScriptError { get; set; }
	}

	/// <inheritdoc cref="IIpProperty"/>
	[DebuggerDisplay("{DebugDisplay}")]
	public class IpPropertyDescriptor<T>
		: DocValuesPropertyDescriptorBase<IpPropertyDescriptor<T>, IIpProperty, T>, IIpProperty
		where T : class
	{
		public IpPropertyDescriptor() : base(FieldType.Ip) { }

		double? IIpProperty.Boost { get; set; }
		bool? IIpProperty.Index { get; set; }
		string IIpProperty.NullValue { get; set; }
		bool? IIpProperty.IgnoreMalformed { get; set; }
		IInlineScript IIpProperty.Script { get; set; }
		OnScriptError? IIpProperty.OnScriptError { get; set; }

		public IpPropertyDescriptor<T> Index(bool? index = true) => Assign(index, (a, v) => a.Index = v);

		[Obsolete("The server always treated this as a noop and has been removed in 7.10")]
		public IpPropertyDescriptor<T> Boost(double? boost) => Assign(boost, (a, v) => a.Boost = v);

		public IpPropertyDescriptor<T> NullValue(string nullValue) => Assign(nullValue, (a, v) => a.NullValue = v);

		public IpPropertyDescriptor<T> IgnoreMalformed(bool? ignoreMalformed = true) => Assign(ignoreMalformed, (a, v) => a.IgnoreMalformed = v);

		/// <inheritdoc cref="IIpProperty.Script" />
		public IpPropertyDescriptor<T> Script(IInlineScript inlineScript) => Assign(inlineScript, (a, v) => a.Script = v);

		/// <inheritdoc cref="IIpProperty.Script" />
		public IpPropertyDescriptor<T> Script(string source) => Assign(source, (a, v) => a.Script = new InlineScript(source));

		/// <inheritdoc cref="IIpProperty.Script" />
		public IpPropertyDescriptor<T> Script(Func<InlineScriptDescriptor, IInlineScript> selector) => Assign(selector, (a, v) => a.Script = v?.Invoke(new InlineScriptDescriptor()));

		/// <inheritdoc cref="IIpProperty.OnScriptError" />
		public IpPropertyDescriptor<T> OnScriptError(OnScriptError? onScriptError) => Assign(onScriptError, (a, v) => a.OnScriptError = v);
	}
}
