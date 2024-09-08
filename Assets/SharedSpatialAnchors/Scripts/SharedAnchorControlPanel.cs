/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
 *
 * Licensed under the Oculus SDK License Agreement (the "License");
 * you may not use the Oculus SDK except in compliance with the License,
 * which is provided at the time of installation or download, or which
 * otherwise accompanies this software in either electronic or hard copy form.
 *
 * You may obtain a copy of the License at
 *
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Oculus SDK
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using PhotonPun = Photon.Pun;
using PhotonRealtime = Photon.Realtime;

public class SharedAnchorControlPanel : MonoBehaviour
{
    [SerializeField]
    private Transform referencePoint;

    [SerializeField]
    private GameObject cubePrefab;
    [SerializeField]
    private GameObject roomLayoutPanelRowPrefab;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    protected GameObject menuPanel;

    [SerializeField]
    protected GameObject lobbyPanel;

    [SerializeField]
    private GameObject roomLayoutPanel;
    [SerializeField]
    private Button createRoomButton;

    [SerializeField]
    private Button joinRoomButton;

    [SerializeField]
    private Image anchorIcon;

    [SerializeField]
    private TextMeshProUGUI pageText;

    [SerializeField]
    private TextMeshProUGUI statusText;

    public TextMeshProUGUI StatusText
    {
        get { return statusText; }
    }

    [SerializeField]
    private TextMeshProUGUI renderStyleText;

    [SerializeField]
    private TextMeshProUGUI roomText;

    List<GameObject> lobbyRowList = new List<GameObject>();

    public TextMeshProUGUI RoomText
    {
        get { return roomText; }
    }

    [SerializeField]
    private TextMeshProUGUI userText;

    public TextMeshProUGUI UserText
    {
        get { return userText; }
    }

    [SerializeField]
    private Button newButton1;
    [SerializeField]
    private Button newButton2;
    [SerializeField]
    private Button newButton3;
    [SerializeField]
    private Button newButton4;
    [SerializeField]
    private Button newButton5;
    [SerializeField]
    private Button newButton6;
    [SerializeField]
    private Button newButton7;
    [SerializeField]
    private Button newButton8;
    [SerializeField]
    private Button newButton9;
    [SerializeField]
    private Button newButton10;
    [SerializeField]
    private Button newButton11;
    [SerializeField]
    private Button newButton12;
    [SerializeField]
    private Button newButton13;
    [SerializeField]
    private Button newButton14;
    [SerializeField]
    private Button newButton15;
    [SerializeField]
    private Button newButton16;
    [SerializeField]
    private Button newButton17;
    [SerializeField]
    private Button newButton18;
    [SerializeField]
    private Button newButton19;
    [SerializeField]
    private Button newButton20;
    [SerializeField]
    private Button newButton21;
    [SerializeField]
    private Button newButton22;


    private bool _isCreateMode;

    private void Start()
    {
        transform.parent = referencePoint;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        if (renderStyleText != null)
        {
            renderStyleText.text = "Render: " + CoLocatedPassthroughManager.Instance.visualization.ToString();
        }
        ToggleRoomButtons(false);

        if (newButton1 != null) newButton1.onClick.AddListener(OnNewButton1Pressed);
        if (newButton2 != null) newButton2.onClick.AddListener(OnNewButton2Pressed);
        if (newButton3 != null) newButton3.onClick.AddListener(OnNewButton3Pressed);
        if (newButton4 != null) newButton4.onClick.AddListener(OnNewButton4Pressed);
        if (newButton5 != null) newButton5.onClick.AddListener(OnNewButton5Pressed);
        if (newButton6 != null) newButton6.onClick.AddListener(OnNewButton6Pressed);
        if (newButton7 != null) newButton7.onClick.AddListener(OnNewButton7Pressed);
        if (newButton8 != null) newButton8.onClick.AddListener(OnNewButton8Pressed);
        if (newButton9 != null) newButton9.onClick.AddListener(OnNewButton9Pressed);
        if (newButton10 != null) newButton10.onClick.AddListener(OnNewButton10Pressed);
        if (newButton11 != null) newButton11.onClick.AddListener(OnNewButton11Pressed);
        if (newButton12 != null) newButton12.onClick.AddListener(OnNewButton12Pressed);
        if (newButton13 != null) newButton13.onClick.AddListener(OnNewButton13Pressed);
        if (newButton14 != null) newButton14.onClick.AddListener(OnNewButton14Pressed);
        if (newButton15 != null) newButton15.onClick.AddListener(OnNewButton15Pressed);
        if (newButton16 != null) newButton16.onClick.AddListener(OnNewButton16Pressed);
        if (newButton17 != null) newButton17.onClick.AddListener(OnNewButton17Pressed);
        if (newButton18 != null) newButton18.onClick.AddListener(OnNewButton18Pressed);
        if (newButton19 != null) newButton19.onClick.AddListener(OnNewButton19Pressed);
        if (newButton20 != null) newButton20.onClick.AddListener(OnNewButton20Pressed);
        if (newButton21 != null) newButton21.onClick.AddListener(OnNewButton21Pressed);
        if (newButton22 != null) newButton22.onClick.AddListener(OnNewButton22Pressed);
    }


    public void OnCreateModeButtonPressed()
    {
        SampleController.Instance.Log("OnCreateModeButtonPressed");

        if (!_isCreateMode)
        {
            SampleController.Instance.StartPlacementMode();
            anchorIcon.color = Color.green;
            _isCreateMode = true;
        }
        else
        {
            SampleController.Instance.EndPlacementMode();
            anchorIcon.color = Color.white;
            _isCreateMode = false;
        }
    }

    public void OnLoadLocalAnchorsButtonPressed()
    {
        if (SampleController.Instance.cachedAnchorSample)
        {
            SharedAnchorLoader.Instance.LoadLastUsedCachedAnchor();
        }
        else
        {
            SharedAnchorLoader.Instance.LoadLocalAnchors();
        }
    }

    public void OnLoadSharedAnchorsButtonPressed()
    {
        SharedAnchorLoader.Instance.LoadSharedAnchors();
    }

    public void OnSpawnCubeButtonPressed()
    {
        SampleController.Instance.Log("OnSpawnCubeButtonPressed");

        SpawnCube();
    }

    public void LogNext()
    {
        if (SampleController.Instance.logText.pageToDisplay >= SampleController.Instance.logText.textInfo.pageCount)
        {
            return;
        }

        SampleController.Instance.logText.pageToDisplay++;
        if(pageText)
            pageText.text = SampleController.Instance.logText.pageToDisplay + "/" + SampleController.Instance.logText.textInfo.pageCount;
    }

    public void LogPrev()
    {
        if (SampleController.Instance.logText.pageToDisplay <= 1)
        {
            return;
        }

        SampleController.Instance.logText.pageToDisplay--;
        if(pageText)
            pageText.text = SampleController.Instance.logText.pageToDisplay + "/" + SampleController.Instance.logText.textInfo.pageCount;
    }

    private void SpawnCube()
    {
        var networkedCube = PhotonPun.PhotonNetwork.Instantiate(cubePrefab.name, spawnPoint.position, spawnPoint.rotation);
        var photonGrabbable = networkedCube.GetComponent<PhotonGrabbableObject>();
        photonGrabbable.TransferOwnershipToLocalPlayer();
    }

    public void ChangeUserPassthroughVisualization()
    {
        CoLocatedPassthroughManager.Instance.NextVisualization();
        if (renderStyleText)
        {
            renderStyleText.text = "Render: " + CoLocatedPassthroughManager.Instance.visualization.ToString();
        }
    }

    public void DisplayMenuPanel()
    {
        menuPanel.SetActive(true);
        lobbyPanel.SetActive(false);
    }

    public void DisplayLobbyPanel()
    {
        lobbyPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void ToggleRoomLayoutPanel(bool active)
    {
        roomLayoutPanel.SetActive(active);
    }

    public void ToggleRoomButtons(bool active)
    {
        if (createRoomButton)
            createRoomButton.interactable = active;

        if (joinRoomButton)
            joinRoomButton.interactable = active;
    }

    public void SetRoomList(List<PhotonRealtime.RoomInfo> roomList)
    {
        foreach (Transform roomTransform in roomLayoutPanel.transform)
        {
            if (roomTransform.gameObject != roomLayoutPanelRowPrefab)
                GameObject.Destroy(roomTransform.gameObject);
        }
        lobbyRowList.Clear();

        if (roomList.Count > 0)
        {
            for (int i = 0; i < roomList.Count; i++)
            {
                if (roomList[i].PlayerCount == 0)
                    continue;

                GameObject newLobbyRow = GameObject.Instantiate(roomLayoutPanelRowPrefab, roomLayoutPanel.transform);
                newLobbyRow.SetActive(true);
                newLobbyRow.GetComponentInChildren<TextMeshProUGUI>().text = roomList[i].Name;
                lobbyRowList.Add(newLobbyRow);
            }
        }
    }

    public void OnReturnToMenuButtonPressed()
    {
        if (PhotonPun.PhotonNetwork.IsConnected)
        {
            PhotonPun.PhotonNetwork.Disconnect();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnNewButton1Pressed()
    {
        Debug.Log("New Button 1 Pressed");
    }

    private void OnNewButton2Pressed()
    {
        Debug.Log("New Button 2 Pressed");
    }

    private void OnNewButton3Pressed()
    {
        Debug.Log("New Button 3 Pressed");
    }

    private void OnNewButton4Pressed()
    {
        Debug.Log("New Button 4 Pressed");
    }

    private void OnNewButton5Pressed()
    {
        Debug.Log("New Button 5 Pressed");
    }

    private void OnNewButton6Pressed()
    {
        Debug.Log("New Button 6 Pressed");
    }

    private void OnNewButton7Pressed()
    {
        Debug.Log("New Button 7 Pressed");
    }

    private void OnNewButton8Pressed()
    {
        Debug.Log("New Button 8 Pressed");
    }

    private void OnNewButton9Pressed()
    {
        Debug.Log("New Button 9 Pressed");
    }

    private void OnNewButton10Pressed()
    {
        Debug.Log("New Button 10 Pressed");
    }

    private void OnNewButton11Pressed()
    {
        Debug.Log("New Button 11 Pressed");
    }

    private void OnNewButton12Pressed()
    {
        Debug.Log("New Button 12 Pressed");
    }

    private void OnNewButton13Pressed()
    {
        Debug.Log("New Button 13 Pressed");
    }

    private void OnNewButton14Pressed()
    {
        Debug.Log("New Button 14 Pressed");
    }

    private void OnNewButton15Pressed()
    {
        Debug.Log("New Button 15 Pressed");
    }

    private void OnNewButton16Pressed()
    {
        Debug.Log("New Button 16 Pressed");
    }

    private void OnNewButton17Pressed()
    {
        Debug.Log("New Button 17 Pressed");
    }

    private void OnNewButton18Pressed()
    {
        Debug.Log("New Button 18 Pressed");
    }

    private void OnNewButton19Pressed()
    {
        Debug.Log("New Button 19 Pressed");
    }

    private void OnNewButton20Pressed()
    {
        Debug.Log("New Button 20 Pressed");
    }

    private void OnNewButton21Pressed()
    {
        Debug.Log("New Button 21 Pressed");
    }

    private void OnNewButton22Pressed()
    {
        Debug.Log("New Button 22 Pressed");
    }


}
