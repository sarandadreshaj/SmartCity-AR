using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections.Generic;
public interface IPanelsService
{
    List<string> GetInstalledPanels(string projectName);
    void AddPanelToProject(string projectName, string panelId);
    void RemovePanelFromProject(string projectName, string panelId);
}
