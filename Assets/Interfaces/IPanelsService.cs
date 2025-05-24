using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPanelService
{   
    List<string> GetInstalledPanels(string projectName, int floorNumber);
}
