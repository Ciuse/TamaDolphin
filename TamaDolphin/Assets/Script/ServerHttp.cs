using UnityEngine;
using System.Collections.Generic;
using System;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

public class ServerHttp : MonoBehaviour
{

    public NetworkEventManager networkEventManager;
    public delegate void RequestHandler(Match match, HttpListenerResponse response, string contRead);

    private Dictionary<Regex, RequestHandler> _requestHandlers = new Dictionary<Regex, RequestHandler>();

    HttpListener _listener;

    private bool isMatching = false;
    private bool isWeb = false;
    private bool isSam = false;
    public string stringaLetta;

    void Update()
    {
        if (isMatching)
        {
            if (isWeb)
            {

                isMatching = false;
                isWeb = false;
                WebButtonFunction(); 

            }
            if (isSam)
            {

                isMatching = false;
                isSam = false;
                SamFunction();

            }
        }
    }

    void Awake()
    {
        // create the dictionnary of Regex and RequestHandler
        _requestHandlers[new Regex(@"^/Web$")] = HandleWebResponse;
        _requestHandlers[new Regex(@"^.*$")] = HandleSamResponse;
    }

    // Use this for initialization
    void Start()
    {
        Debug.Log("ciao");

        _listener = new HttpListener();
        _listener.Prefixes.Add("http://+:2601/");

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

   

    private void HandleSamResponse(Match match, HttpListenerResponse response, string contRead)
    {
        response.StatusCode = (int)HttpStatusCode.OK;
        Stream serverResponseOutput = response.OutputStream;
        response.StatusCode = 200;

        response.Close();


        stringaLetta = contRead;
        isMatching = true;
        isSam = true; 
    }

    public void SamFunction()
    {
        SamEvents samEvents = new SamEvents();
        samEvents = JsonUtility.FromJson<SamEvents>(stringaLetta);
        if (samEvents.events[0].dur == 0 && samEvents.events[0].typ == "rfid")
        {
            string idLetto = samEvents.events[0].val;
            Debug.Log("messaggio ricevutoSam");
            Debug.Log(stringaLetta);

            networkEventManager.HandleSamCardRead(idLetto);
        }
    }
   
    private void HandleWebResponse(Match match, HttpListenerResponse response,  string contRead)
    {

        response.StatusCode = (int)HttpStatusCode.OK;
        Stream serverResponseOutput = response.OutputStream;
        response.StatusCode = 200;
        
        response.Close();

        stringaLetta = contRead;
        isMatching = true;
        isWeb = true;
      
    }

    private void WebButtonFunction()
    {

        string contRead = stringaLetta;
        Debug.Log("messaggio ricevuto");
        Debug.Log(contRead);

        networkEventManager.HandleWebButtonPressed(contRead);
    }


    private void ListenerCallback(IAsyncResult result)
    {
        Debug.Log("Messaggio http ricevuto");
        HttpListener listener = (HttpListener)result.AsyncState;
        // Call EndGetContext to complete the asynchronous operation.
        HttpListenerContext context = listener.EndGetContext(result);
        HttpListenerRequest request = context.Request;
        // Obtain a response object.
        HttpListenerResponse response = context.Response;
        string contRead = new StreamReader(request.InputStream).ReadToEnd();
        

        
        foreach (Regex r in _requestHandlers.Keys)
        {
            Match m = r.Match(request.Url.AbsolutePath);
            if (m.Success)
            {
                (_requestHandlers[r])(m, response, contRead);
                // server waits for the next request
                _listener.BeginGetContext(new AsyncCallback(ListenerCallback), _listener);
                return;
            }
        }

    //    response.StatusCode = 404;
    //    response.Close();
    }


}

[Serializable]
public class SamEvents
{
    public Evt[] events;

}

[Serializable]
public class Evt
{
    public string typ;
    public string val;
    public bool act;
    public int dur;
}