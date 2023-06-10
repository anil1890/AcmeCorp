provider "aws" {
  region = "us-west-2"  # Update with your desired region
}

resource "aws_instance" "AcmeCorpMachine" {
  ami           = "ami-0123456789abcdef0"  
  instance_type = "t2.micro" 

  key_name      = "your-key-pair-name"  

  vpc_security_group_ids = ["your-security-group-id"] 

  user_data = <<-EOF
    <powershell>
    # Install ASP.NET Core Hosting Bundle
    Invoke-WebRequest -Uri https://dotnet.microsoft.com/download/dotnet/thank-you/runtime-aspnetcore-3.1.23-windows-hosting-bundle-installer -OutFile hostingbundle.exe
    Start-Process -Wait -FilePath hostingbundle.exe -ArgumentList "/install", "/quiet"
    Remove-Item hostingbundle.exe

    # Build and deploy your ASP.NET Core application
    $webApiPath = "C:\inetpub\wwwroot\your-web-api"
    git clone https://github.com/your-repo/your-web-api.git $webApiPath
    cd $webApiPath
    dotnet publish -c Release -o ./publish

    # Create IIS site
    Import-Module WebAdministration
    New-WebSite -Name "YourWebApi" -Port 80 -PhysicalPath $webApiPath -ApplicationPool ".NET v4.5"

    # Start the website
    Start-Website -Name "YourWebApi"
    </powershell>
    EOF

  tags = {
    Name = "your-instance-name"  # Replace with your desired instance name
  }
}


# Step 1: Open command prompt and save above content into hcl file
# Step 2: run below command 
terraform init
terraform plan
terraform apply -var="variable_name=value" -var="another_variable=another_value"

