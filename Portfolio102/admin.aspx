<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Portfolio102.admin" %>


<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Admin Panel</title>
    <link rel="stylesheet" href="admin.css" />
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/typed.js/2.0.11/typed.min.js"></script>
    <script src="admin.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <h1>Admin Panel</h1>
        <div class="section">
            <h2>Social Links</h2>
            <div class="actions">
                <asp:Button ID="addSocialLinkBtn" runat="server" CssClass="add-btn" Text="Add Social Link" OnClientClick="showAddSocialLinkModal(); return false;" />
            </div>
            <asp:GridView ID="socialLinksTable" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Alt Text">
                        <ItemTemplate>
                            <asp:Label ID="lblAltText" runat="server" Text='<%# Eval("AltText") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image Path">
                        <ItemTemplate>
                            <asp:Label ID="lblImagePath" runat="server" Text='<%# Eval("ImagePath") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Link">
                        <ItemTemplate>
                            <asp:Label ID="lblLink" runat="server" Text='<%# Eval("Link") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="editSocialButton" runat="server" Text="Edit" CssClass="edit-btn" OnClientClick='<%# "showEditSocialLinkModal(\"" + Eval("AltText") + "\", \"" + Eval("ImagePath") + "\", \"" + Eval("Link") + "\"); return false;" %>' />
                            <asp:Button ID="deleteSocialButton" runat="server" Text="Delete" CssClass="delete-btn" OnClick="deleteSocialLink_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <!-- Add Social Link Modal -->
        <asp:Panel ID="addSocialLinkModal" runat="server" CssClass="modal">
            <div class="modal-content">
                <span class="close" onclick="closeSocialLinkModal()">&times;</span>
                <h2>Add Social Link</h2>
                <label for="altText">Alt Text:</label>
                <asp:TextBox ID="altText" runat="server"></asp:TextBox>
                <label for="imagePath">Image Path:</label>
                <asp:TextBox ID="imagePath" runat="server"></asp:TextBox>
                <label for="link">Link:</label>
                <asp:TextBox ID="link" runat="server"></asp:TextBox>
                <asp:Button ID="addSocialLink" runat="server" Text="Add" OnClick="AddSocialLink_Click" />
            </div>
        </asp:Panel>

        <!-- Edit Social Link Modal -->
        <asp:Panel ID="editSocialLinkModal" runat="server" CssClass="modal">
            <div class="modal-content">
                <span class="close" onclick="closeSocialLinkeditModal()">&times;</span>
                <h2>Edit Social Link</h2>
                <asp:HiddenField ID="editSocialLinkId" runat="server" />
                <label for="editAltText">Alt Text:</label>
                <asp:TextBox ID="editAltText" runat="server"></asp:TextBox>
                <label for="editImagePath">Image Path:</label>
                <asp:TextBox ID="editImagePath" runat="server"></asp:TextBox>
                <label for="editLink">Link:</label>
                <asp:TextBox ID="editLink" runat="server"></asp:TextBox>
                <asp:Button ID="editSocialLink" runat="server" Text="Update" OnClick="EditSocialLink_Click" />
            </div>
        </asp:Panel>




<!-- Projects Section -->
<div class="section">
    <h2>Projects</h2>
    <div class="actions">
        <asp:Button ID="addProjectBtn" runat="server" CssClass="add-btn" Text="Add Project" OnClientClick="showAddProjectModal(); return false;" />
    </div>
    <asp:GridView ID="projectGridView" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Link" HeaderText="Link" />
            <asp:BoundField DataField="ImagePath" HeaderText="Image Path" />
            <asp:BoundField DataField="AltText" HeaderText="Alt Text" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="editProjectBtn" runat="server" Text="Edit" CssClass="edit-btn" OnClientClick='<%# "showEditProjectModal(\"" + Eval("Title") + "\", \"" + Eval("Link") + "\", \"" + Eval("ImagePath") + "\", \"" + Eval("AltText") + "\"); return false;" %>' />
                    <asp:Button ID="deleteProjectBtn" runat="server" Text="Delete" CssClass="delete-btn" OnClick="deleteProject_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>

<!-- Add Project Modal -->
<asp:Panel ID="addProjectModal" runat="server" CssClass="modal">
    <div class="modal-content">
        <span class="close" onclick="closeAddProjectModal()">&times;</span>
        <h2>Add Project</h2>
        <asp:Panel ID="addProjectPanel" runat="server">
            <label for="addTitle">Title:</label>
            <asp:TextBox ID="addTitle" runat="server"></asp:TextBox>
            <label for="addLink">Link:</label>
            <asp:TextBox ID="addLink" runat="server"></asp:TextBox>
            <label for="addImagePath">Image Path:</label>
            <asp:TextBox ID="addImagePath" runat="server"></asp:TextBox>
            <label for="addAltText">Alt Text:</label>
            <asp:TextBox ID="addAltText" runat="server"></asp:TextBox>
            <asp:Button ID="btnAddProject" runat="server" Text="Add" OnClick="AddProject_Click" />
        </asp:Panel>
    </div>
</asp:Panel>

<!-- Edit Project Modal -->
<asp:Panel ID="editProjectModal" runat="server" CssClass="modal">
    <div class="modal-content">
        <span class="close" onclick="closeEditProjectModal()">&times;</span>
        <h2>Edit Project</h2>
        <asp:Panel ID="editProjectPanel" runat="server">
            <asp:HiddenField ID="editProjectId" runat="server" />
            <label for="editTitle">Title:</label>
            <asp:TextBox ID="editTitle" runat="server"></asp:TextBox>
            <label for="editLink">Link:</label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <label for="editImagePath">Image Path:</label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <label for="editAltText">Alt Text:</label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:Button ID="btnEditProject" runat="server" Text="Edit" OnClick="EditProject_Click" />
        </asp:Panel>
    </div>
</asp:Panel>




<!-- Extracurricular Activity Section -->
<div class="section">
    <h2>Extracurricular Activities</h2>
    <div class="actions">
        <asp:Button ID="addActivityBtn" runat="server" CssClass="add-btn" Text="Add Activity" OnClientClick="showAddActivityModal(); return false;" />
    </div>
    <asp:GridView ID="activitiesGridView" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Link Title">
                <ItemTemplate>
                    <asp:Label ID="lblLinkTitle" runat="server" Text='<%# Eval("LinkTitle") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Link">
                <ItemTemplate>
                    <asp:Label ID="lblLink" runat="server" Text='<%# Eval("Link") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Solved Problems">
                <ItemTemplate>
                    <asp:Label ID="lblSolvedProblems" runat="server" Text='<%# Eval("SolvedProblems") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="editActivityButton" runat="server" Text="Edit" CssClass="edit-btn" OnClientClick='<%# "showEditActivityModal(\"" + Eval("TItle") + "\", \"" + Eval("LinkTitle") + "\", \"" + Eval("Link") + "\", \"" + Eval("SolvedProblems") + "\"); return false;" %>' />
                    <asp:Button ID="deleteActivityButton" runat="server" Text="Delete" CssClass="delete-btn" OnClick="deleteActivity_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>

<!-- Add Activity Modal -->
<asp:Panel ID="addActivityModal" runat="server" CssClass="modal">
    <div class="modal-content">
        <span class="close" onclick="closeActivityModal()">&times;</span>
        <h2>Add Activity</h2>
        <label for="activityTitle">Title:</label>
        <asp:TextBox ID="activityTitle" runat="server"></asp:TextBox>
        <label for="activityLinkTitle">Link Title:</label>
        <asp:TextBox ID="activityLinkTitle" runat="server"></asp:TextBox>
        <label for="activityLink">Link:</label>
        <asp:TextBox ID="activityLink" runat="server"></asp:TextBox>
        <label for="activitySolvedProblems">Solved Problems:</label>
        <asp:TextBox ID="activitySolvedProblems" runat="server"></asp:TextBox>
        <asp:Button ID="addActivity" runat="server" Text="Add" OnClick="addActivity_Click" />
    </div>
</asp:Panel>

<!-- Edit Activity Modal -->
<asp:Panel ID="editActivityModal" runat="server" CssClass="modal">
    <div class="modal-content">
        <span class="close" onclick="closeEditActivityModal()">&times;</span>
        <h2>Edit Activity</h2>
        <asp:HiddenField ID="editActivityId" runat="server" />
        <label for="editActivityTitle">Title:</label>
        <asp:TextBox ID="editActivityTitle" runat="server"></asp:TextBox>
        <label for="editActivityLinkTitle">Link Title:</label>
        <asp:TextBox ID="editActivityLinkTitle" runat="server"></asp:TextBox>
        <label for="editActivityLink">Link:</label>
        <asp:TextBox ID="editActivityLink" runat="server"></asp:TextBox>
        <label for="editActivitySolvedProblems">Solved Problems:</label>
        <asp:TextBox ID="editActivitySolvedProblems" runat="server"></asp:TextBox>
        <asp:Button ID="updateActivity" runat="server" Text="Update" OnClick="updateActivity_Click" />
    </div>
</asp:Panel>
















        

        <!-- Mail Section -->


<div class="section">
    <h2>Inbox</h2>
    <asp:GridView ID="mailGridView" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Subject" HeaderText="Subject" />
            <asp:BoundField DataField="Message" HeaderText="Message" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="deleteMailBtn" runat="server" Text="Delete" CssClass="delete-btn" OnClick="deleteMail_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>




    </form>
</body>
</html>