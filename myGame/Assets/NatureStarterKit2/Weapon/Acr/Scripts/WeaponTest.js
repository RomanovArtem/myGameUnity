﻿var drawAnim : String = "Draw";
var fireLeftAnim : String = "Fire";
var reloadAnim : String = "Reload";
var animationGO : GameObject;
/// звук выстрела
var ShootSound : AudioClip;

/// звук перезарядки
var ReloadSound : AudioClip;

 
private var drawWeapon : boolean = false;
private var reloading : boolean = false;
private var GameIsPaused : boolean = false;	

private var AllAmmo : int = 150;
private var Ammo : int = 30;

 
function Start (){
DrawWeapon();
}
 
function Update (){
 
 if (!GameIsPaused)
 {
    if(Input.GetButtonDown ("Fire1") && reloading == false && drawWeapon == false && AllAmmo !=0){
	    Fire();
		Ammo--;
		AllAmmo--;
		PlayShootSound();
        }
        if (Input.GetKeyDown ("r") && reloading == false && drawWeapon == false && AllAmmo != 0 || Ammo <= 0 && AllAmmo !=0){
		GameIsPaused = false;
		PlayReloadSound();
		Reloading();
		Ammo = 30;
        }
       
        if (Input.GetKeyDown ("1") && reloading == false){
        DrawWeapon();
        } 
	}

	if (Input.GetKeyDown(KeyCode.Escape) && !GameIsPaused) {
		InvertBool();
		return;
	}
	if (Input.GetKeyDown(KeyCode.Escape) && GameIsPaused) {
		InvertBool();
		return;
	}
}

function InvertBool(){
	if(GameIsPaused) GameIsPaused = false;
	else if(!GameIsPaused) GameIsPaused = true;
}
 
function Fire(){
    animationGO.GetComponent.<Animation>().CrossFadeQueued(fireLeftAnim, 0.08, QueueMode.PlayNow);
}
 
function DrawWeapon() {
  if(drawWeapon)
    return;
       
        animationGO.GetComponent.<Animation>().Play(drawAnim);
        drawWeapon = true;
        yield WaitForSeconds(0.6);
        drawWeapon = false;
       
}
 
function Reloading(){
     if(reloading) return;
   
        animationGO.GetComponent.<Animation>().Play(reloadAnim);
        reloading = true;
        yield WaitForSeconds(2.0);
        reloading = false;
}

/// воспроизвести звук выстрела
function PlayShootSound() {
	gameObject.GetComponent.<AudioSource>().clip = ShootSound;
    gameObject.GetComponent.<AudioSource>().Play();
}

/// воспроизвести звук перезарядки
function PlayReloadSound() {
	gameObject.GetComponent.<AudioSource>().clip = ReloadSound;
    gameObject.GetComponent.<AudioSource>().Play();
}