import { TestBed } from '@angular/core/testing';
import { AuthenticationService } from './authentication.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { environment } from '../../environments/environment'
fdescribe('AuthenticationService', () => {
 let service: AuthenticationService;
 let httpMock: HttpTestingController;
 const dummyUser: any[] =[{
   email: 'dummy@dummyuser.com',
   password: 'dummy'
   }]
   const dummyCardInfo: any[] =[{
     name: 'dummy',
     cardNumber: 1234567887654321
     }]
 beforeEach(() => {
   TestBed.configureTestingModule({
     providers: [AuthenticationService],
     imports: [HttpClientTestingModule]
   })
   service = TestBed.get(AuthenticationService);
   httpMock = TestBed.get(HttpTestingController);
 });
 afterEach(() => {
   service = null;
   localStorage.removeItem('token');
 });
 it('should be created', () => {
   expect(service).toBeTruthy();
 });
 it('should return true from getToken when there is a token', () => {
   localStorage.setItem('token', '1234');
   expect(service.getToken()).toBeTruthy();
 });
 it('should return false from getToken when there is no token', () => {
   expect(service.getToken()).toBeFalsy();
 });
 it('should return the user from addUser when reidrected to url', () =>{
   service.addUser(dummyUser).subscribe(user=>{
     expect(user).toEqual(dummyUser);
   });
   let request = httpMock.expectOne({
     url: ${environment.BASE_URL}/user/register,
     method: 'POST'
   })
   request.flush(dummyUser);
   httpMock.verify();
 });
 it('should return the user based on id from getUser when reidrected to url', () =>{
   service.getUser(1).subscribe(userInfo=>{
     expect(userInfo).toEqual(1);
   });
   let request = httpMock.expectOne({
     url: 'http://localhost:3000/user/1',
     method: 'GET'
   })
   request.flush(1);
   httpMock.verify();
 });
 it('should return the user from authenticate when reidrected to url', () =>{
   service.authenticate(dummyUser).subscribe(userInfo=>{
     expect(userInfo).toEqual(dummyUser);
   });
   let request = httpMock.expectOne({
     url: ${environment.BASE_URL}/user/login,
     method: 'POST'
   })
   request.flush(dummyUser);
   httpMock.verify();
 });
 it('should return the card info from addCard when reidrected to url', () =>{
   service.addCard(dummyCardInfo).subscribe(cardInfo=>{
     expect(cardInfo).toEqual(dummyCardInfo);
   });
   let request = httpMock.expectOne({
     url: 'http://localhost:51487/api/user/register',
     method: 'POST'
   })
   request.flush(dummyCardInfo);
   httpMock.verify();
 });
 it('should return the user from updateUser when redirected to url', () =>{
   service.updateUser(1,dummyUser).subscribe(userInfo=>{
     expect(userInfo).toEqual(dummyUser);
   });
   let request = httpMock.expectOne({
     url: ${environment.BASE_URL}/user/1,
     method: 'PUT'
   })
   request.flush(dummyUser);
   httpMock.verify();
 });
});