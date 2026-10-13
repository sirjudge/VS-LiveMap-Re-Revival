#!/usr/bin/env bash
PROJECT_ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
DOXYGEN_CONF="$PROJECT_ROOT/modSrc/doxygen.conf"
DOCS_DIR="$PROJECT_ROOT/modSrc/doxygen.conf"

CYAN='\033[0;36m'
GREEN='\033[0;32m'
RED='\033[0;31m'
MAGENTA='\033[0;35m'
YELLOW='\033[0;33m'
GRAY='\033[0;90m'
NC='\033[0m' # No Color

step() { echo -e "${CYAN}==> $1${NC}"; }
success() { echo -e "${GREEN}✓ $1${NC}"; }
error() { echo -e "${RED}✗ $1${NC}"; }



echo ""
echo -e "${MAGENTA}LiveMap Documentation build${NC}"
echo -e "${MAGENTA}====================${NC}"
echo ""


if ! command -v doxygen &> /dev/null; then
    error "Doxygen cli app could not be found"
    exit 1
fi

# Write-Step "Running Doxygen..."
if doxygen $DoxygenConf ; then
    success "Document generation command successful"
    INDEX_FILE="$DOCS_DIR/index.html"
    if [[ -n "$INDEX_FILE" ]]; then
 		success "You can view the documentation at:"
 		success "$INDEX_FILE"
    fi
else
 	error "Doxygen failed with exit code $LASTEXITCODE"
fi
