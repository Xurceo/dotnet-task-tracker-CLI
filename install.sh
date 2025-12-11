#!/bin/sh
set -e

# Path to project folder relative to this script
PROJECT_DIR="./task-tracker"

# Publish a standalone Linux executable
echo "Publishing standalone executable..."
dotnet publish "$PROJECT_DIR" -c Release -r linux-x64 --self-contained true

PUBLISH_DIR="$PROJECT_DIR/bin/Release/net8.0/linux-x64/publish"
INSTALL_DIR="$HOME/.local/bin/task-cli-files"

# Ask user if they want to install
read -p "Install as command 'task-cli' to ~/.local/bin? [y/N]: " answer
if [[ "$answer" =~ ^[Yy]$ ]]; then
    echo "Installing..."

    # Create install directory
    mkdir -p "$INSTALL_DIR"

    # Copy all published files
    cp -r "$PUBLISH_DIR/"* "$INSTALL_DIR/"
    chmod +x "$INSTALL_DIR/task-tracker"
    ln -s "$INSTALL_DIR/task-tracker" ~/.local/bin/task-cli
    echo "Installation complete. Run with:"
    echo "task-cli <args>"
    echo "Make sure ~/.local/bin is in your PATH"
fi
