using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMover : MonoBehaviour
{
    /* Moving the camera along the path. */
    [SerializeField] private float speed;
    public CinemachineVirtualCamera vCam;


    /// <summary>
    /// "The camera's position on the path is increased by the speed variable."
    /// 
    /// The first line of the function is a bit of a mouthful, but it's not too complicated. The first part,
    /// `vCam.GetCinemachineComponent<CinemachineTrackedDolly>()`, is just getting the CinemachineTrackedDolly component
    /// from the vCam variable. The second part, `.m_PathPosition`, is getting the path position variable from the
    /// component. The third part, `+ speed`, is adding the speed variable to the path position variable
    /// </summary>
    void FixedUpdate()
    {
        vCam.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition =
            vCam.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition + speed;
    }

    public void Update()
	{
	 if(SceneManager.GetActiveScene().buildIndex == 1)
		{
			if (vCam.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition >= 170)
        	{
           	 	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        	}
		}
 		if(SceneManager.GetActiveScene().buildIndex == 2)
		{
			if (vCam.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition >= 160)
        	{
           	 	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        	}
		}
	}
}