﻿//
// Copyright (c) 2016 eppz! mobile, Gergely Borbás (SP)
//
// http://www.twitter.com/_eppz
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
// PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE
// OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;


public class DeepLink : MonoBehaviour
{


	public Text label;


#if !UNITY_EDITOR && (UNITY_IOS || UNITY_STANDALONE_OSX)

	[DllImport("__Internal")]
	static extern void DeepLink_Reset();

	[DllImport("__Internal")]
	static extern string DeepLink_GetURL();	

	[DllImport("__Internal")]
	static extern string DeepLink_GetSourceApplication();		


	void Update()	
    {
        if (DeepLink_GetURL() == "") return;
		label.text = DeepLink_GetURL().Replace("override://", "");
		DeepLink_Reset();
    }

#endif


}
