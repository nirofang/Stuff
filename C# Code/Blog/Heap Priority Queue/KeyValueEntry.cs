using System;

namespace ArchesBotMono
{
	public class KeyValueEntry<K, V>
	{
		public K Key {
			get;
			set;
		}

		public V Value {
			get;
			set;
		}

		public KeyValueEntry (K key, V value)
		{
			Key = key;
			Value = value;
		}
	}
}

