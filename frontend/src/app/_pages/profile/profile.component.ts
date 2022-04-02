import { Component, OnInit } from '@angular/core';
import User from 'src/app/_data/User';
import { UserInfoService } from 'src/app/_services/user-info.service';
import { AuthService } from 'src/app/_services/auth.service';
import { Router } from '@angular/router';
import { PICTURES } from 'src/app/_data/ProfilePictures';
import { Picture } from 'src/app/_data/ProfilePictures';
import shared from '../../Shared';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {



  user: User = new User();
  pictures: Picture[] = PICTURES;

  username: string = '';
  email: string = '';
  firstName : string = '';
  lastName : string = '';
  oldPass: string = '';
  newPass1: string = '';
  newPass2: string = '';
  photoId: string = '';
  photoPath: string = '';

  wrongPassBool: boolean = false;
  wrongNewPassBool: boolean = false;

  wrongFirstNameBool: boolean = false;
  wrongLastNameBool: boolean = false;
  wrongUsernameBool: boolean = false;
  wrongEmailBool: boolean = false;
  wrongOldPassBool: boolean = false;
  wrongNewPass1Bool: boolean = false;
  wrongNewPass2Bool: boolean = false;

  pattName: RegExp = /^[a-zA-ZšŠđĐčČćĆžŽ]+([ \-][a-zA-ZšŠđĐčČćĆžŽ]+)*$/;
  pattUsername: RegExp = /^[a-zA-Z0-9]{6,18}$/;
  pattTwoSpaces: RegExp = /  /;
  pattEmail: RegExp = /^[a-zA-Z0-9]+([\.\-\+][a-zA-Z0-9]+)*\@([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}$/;
  pattPassword: RegExp = /.{6,30}$/;


  constructor(private userInfoService: UserInfoService, private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.userInfoService.getUserInfo().subscribe((response) => {

      this.user = response;
      shared.photoId = this.user.photoId;

      this.username = this.user.username;
      this.email = this.user.email;
      this.firstName = this.user.firstName;
      this.lastName = this.user.lastName;
      this.photoId = this.user.photoId;

      for (let i = 0; i < this.pictures.length; i++) {
        if (this.pictures[i].photoId.toString() === this.photoId) {
          this.photoPath = this.pictures[i].path;
          break;
        }
      }
      console.log(this.user);
    });
  }

  saveInfoChanges() {
    if (!(this.checkInfoChanges())) //nije prosao regex
      return;

    let editedUser: User = {
      _id: this.user._id,
      username: this.username,
      email: this.email,
      password: this.user.password,
      firstName: this.firstName,
      lastName: this.lastName,
      photoId: this.photoId
    }

    this.userInfoService.changeUserInfo(editedUser).subscribe((response: any) =>{
      if (this.user.username != editedUser.username) { //promenio username, ide logout
        this.user = editedUser;
        this.resetInfo();
        alert("Nakon promene korisničkog imena, moraćete ponovo da se ulogujete.");
        this.authService.logOut();
        this.router.navigate(['']);
        return;
      }
      alert("Podaci su uspešno promenjeni.");
      this.user = editedUser;
      console.log(this.user);
      this.resetInfo();
    }, (error: any) =>{
      if (error.error == "Username already exists!") {
        alert("Ukucano korisničko ime je već zauzeto!\nIzaberite neko drugo.");
        //(<HTMLSelectElement>document.getElementById("inputUsername")).focus();
        //poruka obavestenja ispod inputa
        this.resetInfo();
      }
    });
  }

  savePasswordChanges() {
    this.wrongPassBool = false;
    this.wrongNewPassBool = false;

    if (!(this.checkPasswordChanges())) //nije prosao regex
      return;

    if (this.newPass1 == '' && this.newPass2 == '') //ne zeli da promeni lozinku
      return;
    //console.log("zeli da promeni lozinku");

    if (this.newPass1 != this.newPass2) { //netacno ponovio novu lozinku
      this.wrongNewPassBool = true;
      this.resetNewPassInputs();
      //console.log("Netacno ponovljena lozinka");
      return;
    }

    let passwordArray: string[] = [this.oldPass, this.newPass1];
    this.userInfoService.changeUserPassword(passwordArray).subscribe((response: any) => {
      //console.log("PROMENIO LOZINKU");
      this.resetNewPassInputs();
      alert("Nakon promene lozinke, moraćete ponovo da se ulogujete.");
      this.authService.logOut();
      this.router.navigate(['']);
    }, (error: any) => {
      console.log("error poruka: ", error.error);
      if (error.error == 'Wrong old password!') {
        this.wrongPassBool = true;
        //(<HTMLSelectElement>document.getElementById("inputPassword")).focus();
        return;
      }
      else if (error.error == 'Identical password!') {
        alert("Stara i nova lozinka su identične.");
        this.resetNewPassInputs();
        //(<HTMLSelectElement>document.getElementById("inputNewPassword")).focus();
        return;
      }
    });
  }

  resetNewPassInputs() {
    this.newPass1 = '';
    this.newPass2 = '';
  }

  resetInfo() {
    this.username = this.user.username;
    this.email = this.user.email;
    this.firstName = this.user.firstName;
    this.lastName = this.user.lastName;
    this.photoId = this.user.photoId;

    for (let i = 0; i < this.pictures.length; i++) {
      if (this.pictures[i].photoId.toString() === this.photoId) {
        this.photoPath = this.pictures[i].path;
        break;
      }
    }
    shared.photoId = this.photoId;
  }
  
  checkPasswordChanges() : boolean {
    this.passwordValidation();

    if (!(this.wrongOldPassBool || this.wrongNewPass1Bool || this.wrongNewPass2Bool))
      return true;
    return false;
  }
  checkInfoChanges() : boolean {
    this.firstName = this.firstName.trim();
    this.lastName = this.lastName.trim();
    this.username = this.username.trim();
    this.email = this.email.trim();

    this.firstNameValidation();
    this.lastNameValidation();
    this.usernameValidation();
    this.emailValidation();

    if (!(this.wrongUsernameBool || this.wrongEmailBool || this.wrongFirstNameBool || this.wrongLastNameBool))
      return true;
    return false;
  }

  isCorrectName(element: string): boolean {
    if (this.pattName.test(element) && !(this.pattTwoSpaces.test(element)) && (element.length >= 1 && element.length <= 30))
      return true;
    return false;
  }
  isCorrectUsername(element: string): boolean {
    if (this.pattUsername.test(element) && !(this.pattTwoSpaces.test(element)) && (element.length >= 1 && element.length <= 30))
      return true;
    return false;
  }
  isCorrectEmail(element: string): boolean {
    if (this.pattEmail.test(element.toLowerCase()) && element.length <= 320)
      return true;
    return false;
  }
  isCorrectPassword(element: string): boolean {
    if (this.pattPassword.test(element))
      return true;
    return false;
  }
  firstNameValidation() {
    if (this.isCorrectName(this.firstName) == true) {
      this.wrongFirstNameBool = false;
      return;
    }
    //(<HTMLSelectElement>document.getElementById('firstName')).focus();
    this.wrongFirstNameBool = true;
  }
  lastNameValidation() {
    if (this.isCorrectName(this.lastName) == true) {
      this.wrongLastNameBool = false;
      return;
    }
    //(<HTMLSelectElement>document.getElementById('lastName')).focus();
    this.wrongLastNameBool = true;
  }
  usernameValidation() {
    if (this.isCorrectUsername(this.username) == true) {
      this.wrongUsernameBool = false;
      return;
    }
    //(<HTMLSelectElement>document.getElementById('username-register')).focus();
    this.wrongUsernameBool = true;
  }
  emailValidation() {
    if (this.isCorrectEmail(this.email) == true) {
      this.wrongEmailBool = false;
      return;
    }
    //(<HTMLSelectElement>document.getElementById('email')).focus();
    this.wrongEmailBool = true;
  }
  passwordValidation() {
    if (this.isCorrectPassword(this.oldPass) && this.isCorrectPassword(this.newPass1) && this.newPass1 == this.newPass2) {
      this.wrongOldPassBool = false;
      this.wrongNewPass1Bool = false;
      this.wrongNewPass2Bool = false;
      return;
    }
    this.oldPass = '';
    this.newPass1 = '';
    this.newPass2 = '';
    //(<HTMLSelectElement>document.getElementById('pass1')).focus();
    this.wrongOldPassBool = true;
    this.wrongNewPass1Bool = true;
    this.wrongNewPass2Bool = true;
  }

}
