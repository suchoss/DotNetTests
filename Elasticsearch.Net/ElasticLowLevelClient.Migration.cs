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
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;
using static Elasticsearch.Net.HttpMethod;

// ReSharper disable InterpolatedStringExpressionIsNotIFormattable
// ReSharper disable once CheckNamespace
// ReSharper disable InterpolatedStringExpressionIsNotIFormattable
// ReSharper disable RedundantExtendsListEntry
namespace Elasticsearch.Net.Specification.MigrationApi
{
	///<summary>
	/// Migration APIs.
	/// <para>Not intended to be instantiated directly. Use the <see cref = "IElasticLowLevelClient.Migration"/> property
	/// on <see cref = "IElasticLowLevelClient"/>.
	///</para>
	///</summary>
	public partial class LowLevelMigrationNamespace : NamespacedClientProxy
	{
		internal LowLevelMigrationNamespace(ElasticLowLevelClient client): base(client)
		{
		}

		///<summary>GET on /_migration/deprecations <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/migration-api-deprecation.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse DeprecationInfo<TResponse>(DeprecationInfoRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_migration/deprecations", null, RequestParams(requestParameters));
		///<summary>GET on /_migration/deprecations <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/migration-api-deprecation.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("migration.deprecations", "")]
		public Task<TResponse> DeprecationInfoAsync<TResponse>(DeprecationInfoRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_migration/deprecations", ctx, null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_migration/deprecations <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/migration-api-deprecation.html</para></summary>
		///<param name = "index">Index pattern</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse DeprecationInfo<TResponse>(string index, DeprecationInfoRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, Url($"{index:index}/_migration/deprecations"), null, RequestParams(requestParameters));
		///<summary>GET on /{index}/_migration/deprecations <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/migration-api-deprecation.html</para></summary>
		///<param name = "index">Index pattern</param>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("migration.deprecations", "index")]
		public Task<TResponse> DeprecationInfoAsync<TResponse>(string index, DeprecationInfoRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, Url($"{index:index}/_migration/deprecations"), ctx, null, RequestParams(requestParameters));
		///<summary>GET on /_migration/system_features <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/migration-api-feature-upgrade.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse GetFeatureUpgradeStatus<TResponse>(GetFeatureUpgradeStatusRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(GET, "_migration/system_features", null, RequestParams(requestParameters));
		///<summary>GET on /_migration/system_features <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/migration-api-feature-upgrade.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("migration.get_feature_upgrade_status", "")]
		public Task<TResponse> GetFeatureUpgradeStatusAsync<TResponse>(GetFeatureUpgradeStatusRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(GET, "_migration/system_features", ctx, null, RequestParams(requestParameters));
		///<summary>POST on /_migration/system_features <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/migration-api-feature-upgrade.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		public TResponse PostFeatureUpgrade<TResponse>(PostFeatureUpgradeRequestParameters requestParameters = null)
			where TResponse : class, IElasticsearchResponse, new() => DoRequest<TResponse>(POST, "_migration/system_features", null, RequestParams(requestParameters));
		///<summary>POST on /_migration/system_features <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/migration-api-feature-upgrade.html</para></summary>
		///<param name = "requestParameters">Request specific configuration such as querystring parameters &amp; request specific connection settings.</param>
		[MapsApi("migration.post_feature_upgrade", "")]
		public Task<TResponse> PostFeatureUpgradeAsync<TResponse>(PostFeatureUpgradeRequestParameters requestParameters = null, CancellationToken ctx = default)
			where TResponse : class, IElasticsearchResponse, new() => DoRequestAsync<TResponse>(POST, "_migration/system_features", ctx, null, RequestParams(requestParameters));
	}
}