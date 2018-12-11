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
    public bool clickButton = false;

    private Match param1;
    private HttpListenerResponse param2;

    private RequestHandler functionToRun;

    void Update()
    {
        if (isMatching)
        {
            isMatching = false;
            function(); //test 


        }
    }

    void Awake()
    {
        // create the dictionnary of Regex and RequestHandler
        _requestHandlers[new Regex(@"^/Sam$")] = HandleSamWebResponse;
        _requestHandlers[new Regex(@"^/Rfid$")] = HandleCardRfidResponse;
        _requestHandlers[new Regex(@"^/Web$")] = HandleWebResponse;
        _requestHandlers[new Regex(@"^.*$")] = HandleSamResponse;
    }

    // Use this for initialization
    void Start()
    {
        Debug.Log("ciao");

        _listener = new HttpListener();
        _listener.Prefixes.Add("http://+:8081/");

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

    private void function()
    {

    }

    private void HandleSamWebResponse(Match match, HttpListenerResponse response, string contRead)
    {

        if (contRead == "1")
        {

            clickButton = true;
            Debug.Log("configurazione avvenuta con successo");
            
        }
       
    }

    private void HandleCardRfidResponse(Match match, HttpListenerResponse response, string contRead)
    {

        Debug.Log("messaggio ricevutoSam");
        Debug.Log(contRead);

        networkEventManager.HandleSamCardRead(contRead);

    }

    private void HandleSamResponse(Match match, HttpListenerResponse response, string contRead)
    {

        SamEvents samEvents = new SamEvents();
        samEvents = JsonUtility.FromJson<SamEvents>(contRead);

        string idLetto = samEvents.events[0].val;
        isMatching = true;

        Debug.Log("messaggio ricevutoSam");
        Debug.Log(contRead);

        networkEventManager.HandleSamCardRead(idLetto);
    }

   
    private void HandleWebResponse(Match match, HttpListenerResponse response,  string contRead)
    {

       
        isMatching = true;
        

        Debug.Log("messaggio ricevuto");
        Debug.Log(contRead);
        
        networkEventManager.HandleWebButtonPressed(contRead);
    }

    
    public string TherapistButtonValue(string buttonValue)
    {
        
        string val = string.Empty;
        

        for (int i = 0; i < buttonValue.Length; i++)
        {
            if (Char.IsDigit(buttonValue[i]))
                val += buttonValue[i];
        }

        if (val.Length == 1 && (val=="0"|| val == "1" ))
        {
           return val;
        }
        else return "qualcosa è andato storto nella stringa passata dal sito web";
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

        response.StatusCode = 404;
        response.Close();
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


