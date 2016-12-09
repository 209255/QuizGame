using System;
using System.Collections;
using UnityEngine;

public class Ticker:MonoBehaviour {
    public float Rate { get { return rate; } }
    private float rate = 0.05f;
    public static Ticker Instance {
        get {
            if ( instacne == null )
                instacne = new GameObject("Ticker").AddComponent<Ticker>();
            return instacne;
        }
    }
    private static Ticker instacne;
    private void Awake() {
        DontDestroyOnLoad(this);
    }

    public void CallRepeating(Action action) {
        StartCoroutine(InternalCallRepeating(action));
    }

    private IEnumerator InternalCallRepeating(Action action) {
        while ( true ) {
            action();
            yield return new WaitForSeconds(rate);
        }
    }
}