<div align="center">

# Task-CLI

![Version](https://img.shields.io/badge/version-1.0.0-blue)
[![License](https://img.shields.io/badge/license-MIT-green)](https://github.com/USERNAME/REPO/blob/main/LICENSE)
[![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![Linux](https://img.shields.io/badge/target-linux--x64-black?logo=linux)](https://kernel.org)
![No Bugs](https://img.shields.io/badge/bugs-0%20found%20%28allegedly%29-green)

A project used to track and manage your tasks

This project is implementaion of task-tracker idea from [roadmap.sh](https://roadmap.sh/projects/task-tracker)

</div>

## Installation

### Build from source (With dotnet)

1. Install **git** and the **.NET SDK** for your distribution.

    ```sh
    # Arch Linux
    sudo pacman -S git dotnet-sdk

    # Fedora
    sudo dnf install git dotnet-sdk-8.0

    # Ubuntu / Kubuntu / Debian
    sudo apt update
    sudo apt install git dotnet-sdk-8.0

    # openSUSE
    sudo zypper install git dotnet-sdk-8_0
    ```

2. Clone and install

    ```sh
    git clone https://github.com/xurceo/dotnet-task-tracker-CLI.git
    cd dotnet-task-tracker-CLI
    sudo chmod +x install.sh && ./install.sh
    ```

## Usage

### After you installed it on your machine, you can:

1.  Create a task

    ```sh
    task-cli add "Sample Task"
    ```

2. Edit description and statuses of the tasks
   
    ```sh
    task-cli update 1 "Updated Sample Task"
    ```

    ```sh
    task-cli mark 1 done
    task-cli mark 2 in-progress
    task-cli mark 3 todo
    ```
    
3. List all tasks

    ```sh
    task-cli list
    ```
    
    And even filter by status

    ```sh
    task-cli list done
    task-cli list in-progress
    task-cli list todo
    ```

4. Delete tasks

    ```sh
    task-cli delete 1
    ```

### By default, tasks are saved in JSON file named DefaultList.JSON in your documents folder

## Support the development

If you like what I do

[![Star Me](https://img.shields.io/badge/Give_me_a_star-⭐-brightgreen)](https://github.com/xurceo/dotnet-task-tracker-CLI/stargazers)
![Emotion Support](https://img.shields.io/badge/support-devs_emotional_state-orange)
