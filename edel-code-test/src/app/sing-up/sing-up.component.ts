import { Component, OnInit } from '@angular/core';
import { User } from '../shared/user.model';
import { HttpClient } from '@angular/common/http';
import { UploadImageService } from '../shared/user.service';


@Component({
  selector: 'app-sing-up',
  templateUrl: './sing-up.component.html',
  styleUrls: ['./sing-up.component.css'],
  providers:[UploadImageService]
})
export class SingUpComponent implements OnInit {
  imageUrl : string = "/assets/img/default-img.png";
  fileToUpload: File=null;

  constructor(private imageService : UploadImageService) { }
  user:User;
  
 ngOnInit() {
  }

  handleFileInput(file: FileList){
    this.fileToUpload=file.item(0);
    var reader= new FileReader();
    reader.onload=(event:any)=>{
      this.imageUrl=event.target.result;
  }
  reader.readAsDataURL(this.fileToUpload);
}

OnSubmit(FirstName,LastName,Gender,DateOfBirth,Image)
{
  this.imageService.postFile(FirstName.value,LastName.value,Gender.value,DateOfBirth.value, this.fileToUpload).subscribe(
    data =>{
      console.log('done');
      FirstName.value = null;
      LastName.value = null;
      Gender.value = null;
      DateOfBirth.value=null;

      Image.value = null;
      this.imageUrl = "/assets/img/default-image.png";
    }
  );
}

} 


