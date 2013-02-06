//
//  Copyright 2012  Patrick Uhlmann
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using NUnit.Framework;

namespace ArchesBotMono
{
	[TestFixture]
	public class PriorityQueueTest
	{
		[Test]
		public void PriorityQueueEnqueTest ()
		{
			PriorityQueue<int> queue = new PriorityQueue<int> ();

			queue.Enqueue (5, 1);
			queue.Enqueue (6, 2);
			queue.Enqueue (6, 2);
			queue.Enqueue (7, 2);
			queue.Enqueue (7, 2);
			queue.Enqueue (7, 2);

			Assert.AreEqual (6, queue.Count);
		}

		[Test]
		public void PriorityQueueDequeTest ()
		{
			PriorityQueue<int> queue = new PriorityQueue<int> ();

			queue.Enqueue (5, 1);
			queue.Enqueue (6, 5);
			queue.Enqueue (6, 5);
			queue.Enqueue (7, 6);
			queue.Enqueue (7, 7);
			queue.Enqueue (7, 2);

			int first = queue.Dequeue ();
			int second = queue.Dequeue ();

			Assert.AreEqual (5, first);
			Assert.AreEqual (7, second);
		}

		[Test]
		public void PriorityQueuePeekTest ()
		{
			PriorityQueue<int> queue = new PriorityQueue<int> ();

			queue.Enqueue (5, 3);
			queue.Enqueue (6, 2);

			Assert.AreEqual (6, queue.Peek ());
		}
	}
}

