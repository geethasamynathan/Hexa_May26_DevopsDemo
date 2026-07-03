# Step-by-Step: Install Jenkins on Windows Machine

Jenkins is a Java-based automation server. On Windows, Jenkins requires **Java 21 or later**, a supported web browser, and a Windows-supported environment. Jenkins provides a native Windows installer and official installation documentation.

---

## 1. Check whether Java is installed

Open **Command Prompt** or **PowerShell** and run:

```powershell
java -version
```

Expected output:

```text
java version "21..."
```

or:

```text
openjdk version "21..."
```

If Java is not installed, install **JDK 21**.

Recommended official options:

```text
Oracle JDK 21
Eclipse Temurin JDK 21
Microsoft Build of OpenJDK 21
```

After installing Java, close and reopen PowerShell, then verify again:

```powershell
java -version
```

Also check:

```powershell
where java
```

Expected:

```text
C:\Program Files\...\bin\java.exe
```

---

## 2. Download Jenkins for Windows

Go to the official Jenkins download page:

```text
https://www.jenkins.io/download/
```

Choose:

```text
Long-Term Support release
```

Then download:

```text
Windows installer
```

Jenkins is available as WAR files, native packages, installers, and Docker images. For Windows beginners, the **Windows installer** is the easiest option.

---

## 3. Run Jenkins Windows Installer

After download, you will get a file like:

```text
jenkins.msi
```

Double-click it.

Follow the wizard:

```text
Next
    → Choose installation folder
    → Select service logon type
    → Choose Jenkins port
    → Select Java path
    → Install
```

Recommended installation folder:

```text
C:\Program Files\Jenkins
```

---

## 4. Choose Service Logon Type

During installation, Jenkins asks how the Windows service should run.

For beginner/local training:

```text
Run service as LocalSystem
```

For company/production machine:

```text
Run service as local or domain user
```

For your training/demo purpose, `LocalSystem` is simpler.

---

## 5. Choose Jenkins Port

Default Jenkins port:

```text
8080
```

Keep it as:

```text
8080
```

Then Jenkins will open at:

```text
http://localhost:8080
```

If port 8080 is already used, choose another port like:

```text
8081
```

---

## 6. Select Java Path

The installer will ask for Java path.

Select the Java installation folder.

Example:

```text
C:\Program Files\Java\jdk-21
```

or:

```text
C:\Program Files\Eclipse Adoptium\jdk-21...
```

The Jenkins Windows installation page lists Java 21 or later as a requirement.

---

## 7. Complete Installation

Click:

```text
Install
```

After installation, Jenkins runs as a Windows service.

---

## 8. Check Jenkins Service

Open Run window:

```text
Windows + R
```

Type:

```text
services.msc
```

Press Enter.

Find:

```text
Jenkins
```

Status should be:

```text
Running
```

If it is stopped:

```text
Right-click Jenkins
    → Start
```

---

## 9. Open Jenkins in Browser

Open browser and go to:

```text
http://localhost:8080
```

If you changed port, use:

```text
http://localhost:8081
```

You should see:

```text
Unlock Jenkins
```

---

## 10. Get Initial Admin Password

Jenkins shows the path of the initial admin password.

Usually it is:

```text
C:\ProgramData\Jenkins\.jenkins\secrets\initialAdminPassword
```

or sometimes:

```text
C:\Program Files\Jenkins\secrets\initialAdminPassword
```

Open the file using Notepad.

You can also run in PowerShell:

```powershell
Get-Content "C:\ProgramData\Jenkins\.jenkins\secrets\initialAdminPassword"
```

Copy the password.

Paste it in Jenkins browser page.

Click:

```text
Continue
```

---

## 11. Install Suggested Plugins

Jenkins will ask:

```text
Install suggested plugins
```

Choose:

```text
Install suggested plugins
```

This installs common plugins such as:

```text
Pipeline
Git
Credentials
Folders
Build tools support
```

Wait until installation completes.

---

## 12. Create First Admin User

Enter details:

```text
Username
Password
Full name
Email
```

Example:

```text
Username: admin
Password: Admin@12345
Full name: Jenkins Admin
Email: your email
```

Click:

```text
Save and Continue
```

---

## 13. Confirm Jenkins URL

Default:

```text
http://localhost:8080/
```

Click:

```text
Save and Finish
```

Then:

```text
Start using Jenkins
```

---

# 14. Verify Jenkins Installation

## Browser check

Open:

```text
http://localhost:8080
```

You should see Jenkins dashboard.

## Windows service check

Open:

```text
services.msc
```

Check:

```text
Jenkins → Running
```

## Command check

If Jenkins is installed as service, you can restart from Services UI.

Or use PowerShell as Administrator:

```powershell
Restart-Service Jenkins
```

Check status:

```powershell
Get-Service Jenkins
```

---

# 15. Install Required Plugins for .NET CI/CD

Go to:

```text
Manage Jenkins
    → Plugins
    → Available Plugins
```

Search and install:

```text
Git plugin
Pipeline plugin
Docker Pipeline plugin
```

Usually `Git` and `Pipeline` come with suggested plugins.

After installing, restart Jenkins if required.

---

# 16. Configure Git Path in Jenkins

Go to:

```text
Manage Jenkins
    → Tools
```

Find:

```text
Git installations
```

If Git is installed, Jenkins may auto-detect it.

To check Git path in PowerShell:

```powershell
where git
```

Example output:

```text
C:\Program Files\Git\cmd\git.exe
```

Use that path in Jenkins if required.

Click:

```text
Save
```

---

# 17. Check Jenkins Can Use Required Tools

After Jenkins installation, open PowerShell and verify these tools:

```powershell
git --version
dotnet --info
docker --version
docker compose version
```

For your .NET CI/CD demo, Jenkins needs access to:

```text
Git
.NET SDK
Docker
Docker Compose
```

---

# 18. Important Note for Docker with Jenkins on Windows

If Jenkins runs as a Windows service, Docker commands may fail because Docker Desktop usually runs under the logged-in user.

For beginner training, the easiest approach is:

```text
Start Docker Desktop manually
Run Jenkins on same machine
Make sure Jenkins service can access Docker
```

If Jenkins cannot run Docker commands, you may see:

```text
docker is not recognized
Cannot connect to Docker daemon
```

Possible fixes:

```text
Restart Jenkins after installing Docker
Restart the machine
Make sure Docker Desktop is running
Run Jenkins using the same Windows user
```

---

# 19. Test Jenkins by Creating a Simple Job

## Step 1: Create job

```text
Jenkins Dashboard
    → New Item
```

Enter:

```text
Test-DotNet-Command
```

Select:

```text
Freestyle project
```

Click:

```text
OK
```

## Step 2: Add build step

Go to:

```text
Build Steps
    → Add build step
    → Execute Windows batch command
```

Add:

```bat
dotnet --info
git --version
```

Click:

```text
Save
```

## Step 3: Build

Click:

```text
Build Now
```

Then open:

```text
Build History
    → Console Output
```

Expected:

```text
.NET SDK information
Git version
Finished: SUCCESS
```

---

# 20. Common Installation Problems

## Problem 1: `java -version` not working

Fix:

```text
Install JDK 21
Set JAVA_HOME
Add Java bin folder to PATH
Restart PowerShell
```

Example environment variable:

```text
JAVA_HOME = C:\Program Files\Java\jdk-21
```

Path entry:

```text
%JAVA_HOME%\bin
```

---

## Problem 2: Jenkins page not opening

Check service:

```text
services.msc
```

Start Jenkins.

Check port:

```powershell
netstat -ano | findstr :8080
```

If another app uses 8080, change Jenkins port.

---

## Problem 3: Initial admin password file not found

Check these locations:

```text
C:\ProgramData\Jenkins\.jenkins\secrets\initialAdminPassword
C:\Program Files\Jenkins\secrets\initialAdminPassword
```

Make sure hidden folders are visible.

---

## Problem 4: Plugin installation failed

Check internet connection.

Then go to:

```text
Manage Jenkins
    → Plugins
    → Advanced settings
```

Use default Jenkins update center.

Retry installation.

---

# 21. After Jenkins Installation: Next Step for ProductAPI CI/CD

After Jenkins is installed successfully, your next steps are:

```text
1. Install Git, .NET SDK 8, Docker Desktop if not already installed.
2. Verify git, dotnet, docker commands.
3. Add Dockerfile to ProductAPI.
4. Add docker-compose.yml.
5. Add Jenkinsfile.
6. Push all files to GitHub.
7. Create Jenkins Pipeline job.
8. Connect Jenkins job with GitHub repository.
9. Run Build Now.
10. Verify ProductAPI container is running.
```

---

# Quick Checklist

```text
Java 21 installed
Jenkins installed
Jenkins service running
http://localhost:8080 opens
Initial admin password entered
Suggested plugins installed
Admin user created
Git plugin available
Pipeline plugin available
Git path configured
dotnet command available
docker command available
```

Once this checklist is complete, Jenkins is ready for your ASP.NET Core `ProductAPI` CI/CD pipeline.
