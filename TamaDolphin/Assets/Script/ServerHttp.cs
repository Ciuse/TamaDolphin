using UnityEngine;
using System.Collections.Generic;
using System;
using System.Net;
using System.Text.RegularExpressions;


public class ServerHttp : MonoBehaviour
{

    public NetworkEventManager networkEventManager;
    public string urlDolphin;
    public string portDolphin;
    public string urlWeb;
    public string portWeb;
    public delegate void RequestHandler(Match match, HttpListenerResponse response);

    private Dictionary<Regex, RequestHandler> _requestHandlers = new Dictionary<Regex, RequestHandler>();

    HttpListener _listener;

    private bool isMatching = false;

    private Match param1;
    private HttpListenerResponse param2;

    private RequestHandler functionToRun;

    void Update()
    {
        if (isMatching)
        {
            functionToRun(param1, param2);
            isMatching = false;

        }
    }

    void Awake()
    {
        // create the dictionnary of Regex and RequestHandler
        _requestHandlers[new Regex(@"^/ $")] = HandleSamCardRead;
        _requestHandlers[new Regex(@"^/ $")] = HandleWebButtonPressed;
    }

    // Use this for initialization
    void Start()
    {

        _listener = new HttpListener();
        _listener.Prefixes.Add("http://127.0.0.1:8080/");

        _listener.Start();

        _listener.BeginGetContext(new AsyncCallback(ListenerCallback), _listener);
    }

    void Destroy()
    {
        if (_listener != null)
        {
            _listener.Close();
        }
    }

    private static void HandleSamCardRead(Match match, HttpListenerResponse response)
    {
        Debug.Log("messaggio ricevuto");
    }

    private static void HandleWebButtonPressed(Match match, HttpListenerResponse response)
    {

    }

    private void ListenerCallback(IAsyncResult result)
    {
        HttpListener listener = (HttpListener)result.AsyncState;
        // Call EndGetContext to complete the asynchronous operation.
        HttpListenerContext context = listener.EndGetContext(result);
        HttpListenerRequest request = context.Request;
        // Obtain a response object.
        HttpListenerResponse response = context.Response;

        foreach (Regex r in _requestHandlers.Keys)
        {
            Match m = r.Match(request.Url.AbsolutePath);
            if (m.Success)
            {
                functionToRun = (_requestHandlers[r]);
                param1 = m;
                param2 = response;
                isMatching = true;
                // server waits fpr the next request
                _listener.BeginGetContext(new AsyncCallback(ListenerCallback), _listener);
                return;
            }
        }

        response.StatusCode = 404;
        response.Close();
    }


}