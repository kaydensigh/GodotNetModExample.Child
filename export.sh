#!/usr/bin/env bash
# Runs Godot export then collects files to package in the mod.
set -o xtrace

usage() { echo "Usage: $0 <export_preset> <destination>" 1>&2; exit 1; }

if [[ -z $1 ]] || [[ -z $2 ]]; then
    usage
fi

EXPORT_PRESET=$1
DESTINATION=$2

PROJECT_PATH=$(find . -name "project.godot")
PROJECT_DIR=$(dirname "${PROJECT_PATH:?}")
TEMP_BUILD_DIR=".godot/mono/temp/"
PROJECT=$(basename $(ls ${PROJECT_DIR:?}/*.csproj))
PROJECT_NAME="${PROJECT%.*}"
PCK_PATH="$TEMP_BUILD_DIR/${PROJECT_NAME:?}.pck"

${GODOT_BIN:?} --headless --export-release "${EXPORT_PRESET:?}" "${PCK_PATH:?}" "${PROJECT_PATH:?}"
cp "${PROJECT_DIR:?}/${PCK_PATH:?}" "${DESTINATION:?}"

copy_dll() {
    DLL_PATH=$(find "${PROJECT_DIR:?}/${TEMP_BUILD_DIR:?}/bin/ExportRelease" -name $1)
    # Only copy if we find exactly one file (otherwise there might be more directories in here than we thought).
    [ $(wc -l <<< "${DLL_PATH:?}") = 1 ] && cp "${DLL_PATH:?}" "${DESTINATION:?}"
}

copy_dll "${PROJECT_NAME:?}.dll"

IFS=$' \t\r\n'
DEPS=$(jq -r '[ .targets | values | .. | objects | .runtime | objects | keys | add ] | unique | .[] | split("/")[-1]' "${PROJECT_DIR:?}/${TEMP_BUILD_DIR:?}/obj/project.assets.json")
for DEP in $DEPS; do
    copy_dll $DEP
done
