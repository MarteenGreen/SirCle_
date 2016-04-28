using UnityEngine;
using System.Collections;
//CODE IS SHIT, NEEDS MEGA CLEANUP, IGNORE FOR NOW(AT LEAST IT WORKS)
public class ThemesScript : MonoBehaviour {

	public AudioClip[] Theme1;
	public AudioClip[] Theme2;
	public AudioClip[] Theme3;
	public AudioClip[] Theme4;

	public AudioSource[] Source;
	public AudioSource[] Sources1;
	public AudioSource[] Sources2;
	public AudioSource[] Sources3;

	public int Test;

	public bool playing = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (Test == 0 && playing == false) {
			for (int j = 0; j <3; j++) {
				StopMusic (j, Theme2, Sources1);}
			for (int j = 0; j <2; j++) {
				StopMusic (j, Theme3, Sources2);
			}
			for (int j = 0; j <3; j++) {
				StopMusic (j, Theme4, Sources3);}

			for (int i = 0; i <3; i++) {

				PlayMusic (i, Theme1, Source);
			}

			playing = true;
		}

		else if (Test == 1 && playing ==false) 
		{
			for (int j = 0; j <3; j++) {
				StopMusic (j, Theme1, Source);}
			for (int j = 0; j <2; j++) {
				StopMusic (j, Theme3, Sources2);
			}
			for (int j = 0; j <3; j++) {
				StopMusic (j, Theme4, Sources3);}
			for (int j = 0; j <3; j++) {
			PlayMusic (j, Theme2, Sources1);
			}
			playing= true;

		}
		else if (Test == 2 && playing ==  false) 
		{
			for (int j = 0; j <3; j++) {
				StopMusic (j, Theme1, Source);}
			for (int j = 0; j <3; j++) {
				StopMusic (j, Theme2, Sources1);}
			for (int j = 0; j <3; j++) {
				StopMusic (j, Theme4, Sources3);}
			for (int j = 0; j <2; j++) {
				PlayMusic (j, Theme3, Sources2);
			}
			playing = true;
		}
		else if (Test == 3 && playing ==  false) 
		{
			for (int j = 0; j <3; j++) {
				StopMusic (j, Theme1, Source);}
			for (int j = 0; j <3; j++) {
				StopMusic (j, Theme2, Sources1);}
			for (int j = 0; j <2; j++) {
				StopMusic (j, Theme3, Sources2);
			}
			for (int j = 0; j <3; j++) {
				PlayMusic (j, Theme4, Sources3);
			}
			playing = true;
		}

	}
	public void PlayMusic(int Piece, AudioClip[]Theme, AudioSource[] SourceA)
	{
		SourceA[Piece].clip = Theme[Piece];
		SourceA[Piece].Play();
		if (Piece != 0) {
			SourceA [Piece].volume = 0.0f;
		}
	}

	public void StopMusic(int Piece, AudioClip[]Theme, AudioSource[] SourceA)
	{
		SourceA[Piece].clip = Theme[Piece];
		SourceA[Piece].Stop();
	}
}
