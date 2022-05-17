// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;

namespace OpenWeatherAPIApplication
{
    /// <summary>
    ///     Класс вызывающий события при добавлении и удалении объектов из коллекции.
    /// </summary>
    [Serializable]
    public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _dictonary;

        private event DictonarySave Notify;

        private delegate void DictonarySave(Dictionary<TKey, TValue> data);
        public ObservableDictionary()
        {
            _dictonary = new Dictionary<TKey, TValue>();
            Notify += Storage.Save;
        }

        public ObservableDictionary(Dictionary<TKey, TValue> dictionary)
        {
            _dictonary = dictionary;
            Notify += Storage.Save;
        }

        /// <summary>
        ///     Свойство, возвращающее количество элементов
        /// </summary>
        public int Count => _dictonary.Count;

        /// <summary>
        ///     Свойство, указывающее, доступна ли коллекция для чтения
        /// </summary>
        public bool IsReadOnly => ((ICollection<KeyValuePair<TKey, TValue>>) _dictonary).IsReadOnly;

        /// <summary>
        ///     Свойство, возвращающее ключи элементов
        /// </summary>
        public ICollection<TKey> Keys => _dictonary.Keys;

        /// <summary>
        ///     Свойство, возвращающее значения элементов
        /// </summary>
        public ICollection<TValue> Values => _dictonary.Values;

        /// <summary>
        ///     Свойство возвращающее или выставляющее значение по ключу
        /// </summary>
        /// <param name="key">Ключ элемента</param>
        public TValue this[TKey key]
        {
            get => _dictonary[key];
            set => _dictonary[key] = value;
        }

        /// <summary>
        ///     Получает перечислитель
        /// </summary>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _dictonary.GetEnumerator();
        }

        /// <summary>
        ///     Получает перечислитель
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        ///     Добавляет элемент в словарь
        /// </summary>
        /// <param name="item">Элемент для добавления</param>
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            if (!Contains(item))
                _dictonary.Add(item.Key, item.Value);
            else
                _dictonary[item.Key] = item.Value;

            Notify?.Invoke(_dictonary);
        }

        /// <summary>
        ///     Очищает словарь
        /// </summary>
        public void Clear()
        {
            _dictonary.Clear();
        }

        /// <summary>
        ///     Проверяет, есть ли в словаре заданный элемент
        /// </summary>
        /// <param name="item">Элемент для проверки</param>
        /// <returns>Есть ли элемент Да/Нет</returns>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _dictonary.ContainsValue(item.Value);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Удаляет элемент из словаря
        /// </summary>
        /// <param name="item">Удаляемый элемент</param>
        /// <returns>Удалён ли элемент Да/Нет</returns>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            var isRemoved = _dictonary.Remove(item.Key);

            Notify?.Invoke(_dictonary);

            return isRemoved;
        }

        /// <summary>
        ///     Добавляет элемент в словарь
        /// </summary>
        /// <param name="key">Ключ элемента</param>
        /// <param name="value">Значение элемента</param>
        public void Add(TKey key, TValue value)
        {
            if (!ContainsValue(value))
                _dictonary.Add(key, value);
            else
                _dictonary[key] = value;

            Notify?.Invoke(_dictonary);
        }

        /// <summary>
        ///     Проверяет есть ли такой элемент по указанному ключу
        /// </summary>
        /// <param name="key">Ключ элемента</param>
        /// <returns>Есть ли такой элемент Да/Нет</returns>
        public bool ContainsKey(TKey key)
        {
            return _dictonary.ContainsKey(key);
        }

        /// <summary>
        ///     Проверяет есть ли такой элемент по указанным данным
        /// </summary>
        /// <param name="value">Ключ элемента</param>
        /// <returns>Есть ли такой элемент Да/Нет</returns>
        public bool ContainsValue(TValue value)
        {
            return !_dictonary.ContainsValue(value);
        }

        /// <summary>
        ///     Удаляет элемент из словаря
        /// </summary>
        /// <param name="key">Ключ элемента</param>
        /// <returns>Удалён ли элемент Да/Нет</returns>
        public bool Remove(TKey key)
        {
            var isRemoved = _dictonary.Remove(key);

            Notify?.Invoke(_dictonary);

            return isRemoved;
        }

        /// <summary>
        ///     Проверяет есть ли такой элемент по указанному ключу
        /// </summary>
        /// <param name="key">Ключ элемента</param>
        /// <param name="value">Значение элемента</param>
        /// <returns>Есть ли такой элемент Да/Нет</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return _dictonary.TryGetValue(key, out value);
        }
    }
}