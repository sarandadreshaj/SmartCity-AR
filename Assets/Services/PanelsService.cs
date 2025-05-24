using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class PanelsService : MonoBehaviour, IPanelService
{
    private List<ProjectData> mockupData;

    // Constructor for PanelsService class
    public PanelsService()
    {
        // Initialize mockupData from JSON string
        string jsonMockupData = @"[
            {
                ""ProjectName"": ""111 Gleenwood"",
                ""InstalledPanels"": [""3EW.1"", ""3EW.3"", ""3EW.4""]
            },
            {
                ""ProjectName"": ""Test"",
                ""InstalledPanels"": [""3EW.5"", ""3EW.6"", ""3EW.7""]
            }
        ]";
        // Deserialize JSON string to list of ProjectData objects
        mockupData = JsonConvert.DeserializeObject<List<ProjectData>>(jsonMockupData);
    }

    //returns the list of installed panels associated with a specific project name
    public List<string> GetInstalledPanels(string projectName, int floorNumber)
    {
        //checks if the "ProjectName" property of each 'ProjectData' object in the 'mockupData' list is equal to the 'projectName' string
        var projectData = mockupData.Find(data => data.ProjectName.Equals(projectName, StringComparison.OrdinalIgnoreCase));
        if (projectData != null)
        {
            return projectData.InstalledPanels;
        }
        else
        {
            return new List<string>();
        }
    }

    private class ProjectData
    {
        public string ProjectName { get; set; }
        public List<string> InstalledPanels { get; set; }
    }

    // Start is called before the first frame update
    void Start()
    {
        IPanelService panelService = new PanelsService();
        string projectName = "111 GleenWood";
        int floorNumber =7;
        List<string> installedPanels = panelService.GetInstalledPanels(projectName, floorNumber);
        Debug.Log($"Installed Panels for Project {projectName} in floor {floorNumber} : {string.Join(", ", installedPanels)}");
    }

    // Update is called once per frame
    void Update()
    {
    }
}