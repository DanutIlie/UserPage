import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class UploadImageService {

  constructor(private http : HttpClient) { }

  postFile(FirstName: string,LastName: string,Gender: string,DateOfBirth: string, fileToUpload: File) {
    const endpoint = 'http://localhost:49805/api/image';
    const formData: FormData = new FormData();
    formData.append('Image', fileToUpload, fileToUpload.name);
    formData.append('FirstName', FirstName);
    formData.append('LastName', LastName);
    formData.append('Gender', Gender);
    formData.append('DateOfBirth', DateOfBirth);
    return this.http
      .post(endpoint, formData);
  }

}