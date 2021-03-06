// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information
// ███╗   ██╗ ██████╗ ████████╗██╗ ██████╗███████╗
// ████╗  ██║██╔═══██╗╚══██╔══╝██║██╔════╝██╔════╝
// ██╔██╗ ██║██║   ██║   ██║   ██║██║     █████╗  
// ██║╚██╗██║██║   ██║   ██║   ██║██║     ██╔══╝  
// ██║ ╚████║╚██████╔╝   ██║   ██║╚██████╗███████╗
// ╚═╝  ╚═══╝ ╚═════╝    ╚═╝   ╚═╝ ╚═════╝╚══════╝
// -----------------------------------------------
//  
// This file is automatically generated 
// Please do not edit these files manually
// Run the following in the root of the repos:
//
// 		*NIX 		:	./build.sh codegen
// 		Windows 	:	build.bat codegen
//
// -----------------------------------------------
// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

// ReSharper disable once CheckNamespace
namespace Elasticsearch.Net.Specification.DanglingIndicesApi
{
	///<summary>Request options for DeleteDanglingIndex <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/modules-gateway-dangling-indices.html</para></summary>
	public class DeleteDanglingIndexRequestParameters : RequestParameters<DeleteDanglingIndexRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.DELETE;
		public override bool SupportsBody => false;
		///<summary>Must be set to true in order to delete the dangling index</summary>
		public bool? AcceptDataLoss
		{
			get => Q<bool? >("accept_data_loss");
			set => Q("accept_data_loss", value);
		}

		///<summary>Specify timeout for connection to master</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout</summary>
		public TimeSpan Timeout
		{
			get => Q<TimeSpan>("timeout");
			set => Q("timeout", value);
		}
	}

	///<summary>Request options for ImportDanglingIndex <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/modules-gateway-dangling-indices.html</para></summary>
	public class ImportDanglingIndexRequestParameters : RequestParameters<ImportDanglingIndexRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.POST;
		public override bool SupportsBody => false;
		///<summary>Must be set to true in order to import the dangling index</summary>
		public bool? AcceptDataLoss
		{
			get => Q<bool? >("accept_data_loss");
			set => Q("accept_data_loss", value);
		}

		///<summary>Specify timeout for connection to master</summary>
		public TimeSpan MasterTimeout
		{
			get => Q<TimeSpan>("master_timeout");
			set => Q("master_timeout", value);
		}

		///<summary>Explicit operation timeout</summary>
		public TimeSpan Timeout
		{
			get => Q<TimeSpan>("timeout");
			set => Q("timeout", value);
		}
	}

	///<summary>Request options for List <para>https://www.elastic.co/guide/en/elasticsearch/reference/master/modules-gateway-dangling-indices.html</para></summary>
	public class ListDanglingIndicesRequestParameters : RequestParameters<ListDanglingIndicesRequestParameters>
	{
		public override HttpMethod DefaultHttpMethod => HttpMethod.GET;
		public override bool SupportsBody => false;
	}
}