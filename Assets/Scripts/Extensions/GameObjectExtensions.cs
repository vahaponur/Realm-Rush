using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Represents GameObject extension methods
/// </summary>
public static class GameObjectExtensions 
{
    #region Serialized Fields
    #endregion

    #region Private Fields
    #endregion

    #region Public Properties
    #endregion

 
    
    #region PublicMethods
    
    /// <summary>
    /// Disables all gameobject in the array
    /// </summary>
    /// <param name="arr">GameObject array to extend</param>
    public static void DisableAll(this GameObject[] arr)
    {
        foreach (GameObject gameObject in arr)
        {
            gameObject.SetActive(false);
        }
    }
    
    /// <summary>
    /// Enables all gameobject in the array
    /// </summary>
    /// <param name="arr">GameObject array to extend</param>
    public static void EnableAll(this GameObject[] arr)
    {
        foreach (GameObject gameObject in arr)
        {
            gameObject.SetActive(true); 
        }
    }
    
    /// <summary>
    /// Disables all gameobject in the list
    /// </summary>
    /// <param name="list">GameObject list to extend</param>
    public static void DisableAll(this List<GameObject> list)
    {
        foreach (GameObject gameObject in list)
        {
            gameObject.SetActive(false);
        
        }
    }
    
    /// <summary>
    /// Enables all gameobject in the list
    /// </summary>
    /// <param name="arr">GameObject list to extend</param>
    public static void EnableAll(this List<GameObject> list)
    {
        foreach (GameObject gameObject in list)
        {
            gameObject.SetActive(true); 
        }
    }
    
    /// <summary>
    /// Gets the given component from all gameobjects in this array
    /// </summary>
    /// <param name="gameObjects">Gameobject array to extend</param>
    /// <typeparam name="T">Component Type</typeparam>
    /// <returns>Componenet Array</returns>
    /// <exception cref="Exception">Component cannot be found</exception>
    public static T[] GetComponentAll<T> (this GameObject[] gameObjects) where  T : Component
    {
        T[] components = new T[gameObjects.Length];
        for (int i = 0; i < gameObjects.Length; i++)
        {
            components[i] = gameObjects[i].GetComponent<T>();
            if (components[i] == null)
            {
                throw new Exception($"Component cannot be found on index {i}");
            }
        }

        return components;
    }
    /// <summary>
    /// Gets the given component from all gameobjects in this list
    /// </summary>
    /// <param name="gameObjects">Gameobject list to extend</param>
    /// <typeparam name="T">Component Type</typeparam>
    /// <returns>Component List</returns>
    public static List<T> GetComponentAll<T>(this List<GameObject> gameObjects) where T : Component
    {
         return gameObjects.ToArray().GetComponentAll<T>().ToList();
    }

    #endregion
    
    #region PrivateMethods
    #endregion
}
