// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Collections.Generic;

namespace Nest
{
	public class VariableWidthHistogramBucket : BucketBase
	{
		public VariableWidthHistogramBucket(IReadOnlyDictionary<string, IAggregate> dict) : base(dict) { }

		public double Key { get; set; }

		public double Minimum { get; set; }

		public double Maximum { get; set; }

		public long DocCount { get; set; }
	}
}
