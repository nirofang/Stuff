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
	public class HeapPriorityQueueTest
	{
		[Test]
		public void HeapPriorityQueueRemoveEmptyTest ()
		{
			HeapPriorityQueue<int> queue = new HeapPriorityQueue<int> (10);
			Assert.AreEqual (0, queue.Dequeue());
		}

		[Test]
		public void HeapPriorityQueuePeekEmptyTest ()
		{
			HeapPriorityQueue<int> queue = new HeapPriorityQueue<int> (10);
			Assert.AreEqual (0, queue.Peek());
		}

		[Test]
		public void HeapPriorityQueueEmptyItTest ()
		{
			HeapPriorityQueue<int> queue = new HeapPriorityQueue<int> (10);
			
			queue.Enqueue (5, 1);
			queue.Enqueue (6, 2);
			queue.Enqueue (6, 3);
			queue.Enqueue (7, 4);
			queue.Enqueue (8, 5);
			queue.Enqueue (9, 6);

			queue.Dequeue();
			queue.Dequeue();
			queue.Dequeue();
			queue.Dequeue();
			queue.Dequeue();
			Assert.AreEqual(9, queue.Dequeue());

			Assert.AreEqual (0, queue.Count);
		}

		[Test]
		public void HeapPriorityQueueEnqueTest ()
		{
			HeapPriorityQueue<int> queue = new HeapPriorityQueue<int> (10);
			
			queue.Enqueue (5, 1);
			queue.Enqueue (6, 2);
			queue.Enqueue (6, 2);
			queue.Enqueue (7, 2);
			queue.Enqueue (7, 2);
			queue.Enqueue (7, 2);
			
			Assert.AreEqual (6, queue.Count);
		}
		
		[Test]
		public void HeapPriorityQueueDequeTest ()
		{
			HeapPriorityQueue<int> queue = new HeapPriorityQueue<int> (10);
			
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

			Assert.AreEqual(4, queue.Count);
		}

		[Test]
		public void HeapPriorityQueueUpdatePriorityTest ()
		{
			HeapPriorityQueue<int> queue = new HeapPriorityQueue<int> (10);
			
			queue.Enqueue (5, 1);
			queue.Enqueue (6, 3);
			queue.Enqueue (7, 5);
			queue.Enqueue (8, 6);
			queue.Enqueue (9, 7);
			queue.Enqueue (10, 2);

			queue.UpdatePriority(5, 10);
			queue.UpdatePriority(6, 11);
			
			int first = queue.Dequeue ();
			int second = queue.Dequeue ();
			
			Assert.AreEqual (10, first);
			Assert.AreEqual (7, second);

			Assert.AreEqual(4, queue.Count);
		}

		[Test]
		public void HeapPriorityQueueUpdatePriorityLowestTest ()
		{
			HeapPriorityQueue<int> queue = new HeapPriorityQueue<int> (10);
			
			queue.Enqueue (5, 2);
			queue.Enqueue (6, 3);
			queue.Enqueue (7, 4);
			queue.Enqueue (8, 5);
			queue.Enqueue (9, 6);
			queue.Enqueue (10, 7);
			
			queue.UpdatePriority(5, 0);
			queue.UpdatePriority(6, 1);
			
			int first = queue.Dequeue ();
			int second = queue.Dequeue ();
			int third = queue.Dequeue();
			
			Assert.AreEqual (5, first);
			Assert.AreEqual (6, second);
			Assert.AreEqual (7, third);
			
			Assert.AreEqual(3, queue.Count);
		}
		
		[Test]
		public void HeapPriorityQueuePeekTest ()
		{
			HeapPriorityQueue<int> queue = new HeapPriorityQueue<int> (10);
			
			queue.Enqueue (5, 3);
			queue.Enqueue (6, 2);
			
			Assert.AreEqual (6, queue.Peek ());
			Assert.AreEqual (2, queue.Count);
		}
	}
}

