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
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace ArchesBotMono
{
	public class PriorityQueue<T>
	{
		SortedDictionary<int, Queue<T>> storage;

		public PriorityQueue ()
		{
			storage = new SortedDictionary<int, Queue<T>> ();
		}

		public bool IsEmpty ()
		{
			return (Count == 0);
		}

		public int Count {
			get;
			private set;
		}

		public void Enqueue (T item, int prio)
		{
			if (!storage.ContainsKey (prio)) {
				storage.Add (prio, new Queue<T> ());
			} 

			storage [prio].Enqueue (item);
			Count++;
		}

		public T Dequeue ()
		{
			if (IsEmpty ()) {
				return default(T);
			} else {
				var firstQueue = GetFirstQueue();
				T elem = firstQueue.Dequeue();
				RemoveFirstQueueIfEmpty();
				Count--;
				return elem;
			}
		}

		public T Peek ()
		{
			if (IsEmpty ())
				return default(T);
			else {
				var firstQueue = GetFirstQueue();
				return firstQueue.Peek();
			}
		}

		private Queue<T> GetFirstQueue() {
			var enumerator = storage.GetEnumerator();
			enumerator.MoveNext();
			return enumerator.Current.Value;
		}

		private void RemoveFirstQueueIfEmpty ()
		{
			var enumerator = storage.GetEnumerator ();
			enumerator.MoveNext ();
			if (enumerator.Current.Value.Count == 0) {
				storage.Remove(enumerator.Current.Key);
			}
		}
	}
}