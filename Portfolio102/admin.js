// Show add social link modal
function showAddSocialLinkModal() {
    document.getElementById("addSocialLinkModal").style.display = "block";
}

// Close add social link modal
function closeSocialLinkModal() {
    document.getElementById("addSocialLinkModal").style.display = "none";
}

// Show edit social link modal
function showEditSocialLinkModal(altText, imagePath, link) {
    document.getElementById("editAltText").value = altText;
    document.getElementById("editImagePath").value = imagePath;
    document.getElementById("editLink").value = link;
    document.getElementById("editSocialLinkModal").style.display = "block";
}

// Close edit social link modal
function closeSocialLinkeditModal() {
    document.getElementById("editSocialLinkModal").style.display = "none";
}



// Function to show the add project modal
function showAddProjectModal() {
    var addProjectModal = document.getElementById('addProjectModal');
    addProjectModal.style.display = 'block';
}

// Function to close the add project modal
function closeAddProjectModal() {
    var addProjectModal = document.getElementById('addProjectModal');
    addProjectModal.style.display = 'none';
}

// Function to show the edit project modal with pre-filled data
function showEditProjectModal(title, link, imagePath, altText) {
    var editProjectModal = document.getElementById('editProjectModal');
    editProjectModal.style.display = 'block';

    // Populate the input fields with pre-filled data
    document.getElementById('editTitle').value = title;
    document.getElementById('TextBox1').value = link;
    document.getElementById('TextBox2').value = imagePath;
    document.getElementById('TextBox3').value = altText;
}

// Function to close the edit project modal
function closeEditProjectModal() {
    var editProjectModal = document.getElementById('editProjectModal');
    editProjectModal.style.display = 'none';
}



// Function to show the modal for adding an activity
function showAddActivityModal() {
    var modal = document.getElementById("addActivityModal");
    modal.style.display = "block";
}

// Function to close the modal for adding an activity
function closeActivityModal() {
    var modal = document.getElementById("addActivityModal");
    modal.style.display = "none";
}

// Function to show the modal for editing an activity
function showEditActivityModal(link, linkTitle, title, solvedProblems) {
    var modal = document.getElementById("editActivityModal");
    modal.style.display = "block";

    // Populate textboxes with current data
    document.getElementById("editActivityLink").value = link;
    document.getElementById("editActivityLinkTitle").value = linkTitle;
    document.getElementById("editActivityTitle").value = title;
    document.getElementById("editActivitySolvedProblems").value = solvedProblems;
}

// Function to close the modal for editing an activity
function closeEditActivityModal() {
    var modal = document.getElementById("editActivityModal");
    modal.style.display = "none";
}
