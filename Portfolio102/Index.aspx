<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Portfolio102.Index" %>

<!DOCTYPE html>
<html lang="en">
  <head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>My Portfolio</title>
    <link rel="stylesheet" href="style.css" />
    <link rel="stylesheet" href="mediaquery.css" />
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/typed.js/2.0.11/typed.min.js"></script>
  </head>
  <body>
    <section id = "home">
    <nav id="desktop-nav">
      <div class="logo">Sumaiya Rahim</div>
      <div>
        <ul class="nav-links">
          <li><a href="#about">About</a></li>
          <li><a href="#contact">Contact</a></li>
          <li><a href="#experience">Experience</a></li>
          <li><a href="#projects">Projects</a></li>
          <li><a href="#activities">Extracurricular Activities</a></li>
        </ul>
      </div>
    </nav>
    <nav id="hamburger-nav">
      <div class="logo">Sumaiya Rahim</div>
      <div class="hamburger-menu">
        <div class="hamburger-icon" onclick="toggleMenu()">
          <span></span>
          <span></span>
          <span></span>
        </div>
        <div class="menu-links">
          <li><a href="#about" onclick="toggleMenu()">About</a></li>
          <li><a href="#experience" onclick="toggleMenu()">Experience</a></li>
          <li><a href="#projects" onclick="toggleMenu()">Projects</a></li>
          <li><a href="#contact" onclick="toggleMenu()">Contact</a></li>
          <li><a href="#activities" onclick="toggleMenu()">Extracurricular Activities</a></li>
          <li style="padding-top: 10px;"><a href="#home" onclick="toggleMenu()"><h3><b>Back</b></h3></a></li>
        </div>
      </div>
    </nav>
  </section>

    <section id="profile">
        <div class="section__pic-container">
          <img
           src="./assets/sharee.jpg";
           alt="Sumaiya Rahim"
           class="profile-pic" 
         img>
        </div>
    </div>
    <div class="section__text">
      <p class="section__text__p1">Hey, This is</p>
      <h1 class="title">Sumaiya Rahim</h1>
      <p class="section__text__p2">Full-Stack Developer</p>
      <!-- <a href="#contact">Contact Me</a> -->
      <div class="btn-container">
        <button
          class="btn btn-color-2"
          onclick="window.open('./assets/resume-example.pdf')"
        >
          Download CV
        </button>
        <button class="btn btn-color-1" onclick="location.href='./#contact'">
          Contact Info
        </button>
      </div>
      <div id="socials-container">
              <asp:Repeater ID="SocialMediaRepeater" runat="server">
        <ItemTemplate>
            <a href='<%# Eval("Link") %>' target="_blank">
                <img src='<%# Eval("ImagePath") %>' alt='<%# Eval("AltText") %>' class="icon" />
            </a>
        </ItemTemplate>
    </asp:Repeater>
      </div>
    </div>
    </section>
    <section id="about">
      <p class="section__text__p1">My Introduction</p>
      <h1 class="title">About Me</h1>
      <div class="section-container">
        <div class="section__pic-container">
          <img src="./assets/picture.jpg" alt="Profile picture" class="about-pic" />
        </div>
        <div class="about-details-container">
          <div class="about-containers">
            <div class="details-container">
              <img src="./assets/Experience.png" alt="Experience icon" class="icon" />
              <h3>Experience</h3>
              <p>As I am still an undergraduate, I don't have much experience. <br/> Worked on a few Projects using C++, JAVA, Python, PHP, ASP.net</p>
            </div>
            <div class="details-container">
              <img src="./assets/education.jpg" alt="Education icon" class="icon" />
              <h3>Education</h3>
              <p>SSC(VNS), HSC(VNSC)<br/>Pursuing B.Sc. Engineering Degree(KUET)</p>
            </div>
          </div>
          <div class="text-container">
            <p>
              Currently I'm living in str. I'm a 3rd year CSE student at <strong>KUET</strong>. I'm an avid learner and got so much patience. Somedays 
              I love what I learn and somedays I don't.
            <br/>
              I learnt C++ when I got into KUET. Now I know many other languages like <strong>Java, Python, PHP, HTML, CSS</strong>. I took part in a regional contest. I also took parts in different Competitive Programming Contests. I did 
              take part in a <strong> national programming contest </strong>as well. Other than that I also attend programming contests on online platforms to gain knowledge about logic building.
            <br/>
            <br>
          </div>
          <div class="about__info">
            <div >
                <span class="about__info-title">05+</span>
                <span class="about__info-name">Participated<br>Onsite Contests </span>
            </div>
    
            <div>
                <span class="about__info-title">500+</span>
                <span class="about__info-name">Solved <br> Problems </span>
            </div>
    
            <div>
                <span class="about__info-title">03+</span>
                <span class="about__info-name">Completed <br> projects </span>
            </div>
          </div>
        </div>
      </div>
      <!-- <img src="./assets/arrow.png" alt="Arrow icon" class="arrow" onclick="location.href='./#experience'" /> -->
    </section>
    

    <section id="experience">
      <p class="section__text__p1">Explore My</p>
      <h1 class="title">Experience</h1>
      
      <p>I have worked on various languages to make projects and for academic purposes. <br> I recently learnt CSS and JavaScript. I also learnt MySQL to work on databse.</p>
      <!-- Frontend Segment -->
      <br>
      <!-- <img src="./assets/arrow.png" alt="Arrow icon" class="arrow" onclick="location.href='./#projects'" /> -->
  
      <div class="experience-details-container frontend">
        <h2>Frontend Development</h2>
        <p>1 year</p>
        <br>
        <div class="column right">
          <div class="bars">
            <div class="progress-name"><h4>HTML</h4></div>
            <div class="progress">
              <div class="progress-in" style="width: 90%;"></div>
              <div class="skill-percent"><span>90%</span></div>
            </div>
          </div>
          <div class="bars">
            <div class="progress-name"><h4>CSS</h4></div>
            <div class="progress">
              <div class="progress-in" style="width: 82%;"></div>
              <div class="skill-percent"><span>82%</span></div>
            </div>
          </div>
          <div class="bars">
            <div class="progress-name"><h4>JavaScript</h4></div>
            <div class="progress">
              <div class="progress-in" style="width: 80%;"></div>
              <div class="skill-percent"><span>80%</span></div>
            </div>
          </div>
          
        </div>
      </div>
    
      <!-- Backend Segment -->
      <div class="experience-details-container backend">
        <h2>Backend Development</h2>
        <p>Two years</p>
        <br>
        <div class="column right">
          <div class="bars">
            <div class="progress-name"><h4>Python</h4></div>
            <div class="progress">
              <div class="progress-in" style="width: 90%;"></div>
              <div class="skill-percent"><span>90%</span></div>
            </div>
          </div>
          <div class="bars">
            <div class="progress-name"><h4>Java</h4></div>
            <div class="progress">
              <div class="progress-in" style="width: 60%;"></div>
                <div class="skill-percent"><span>60%</span></div>
            </div>
          </div>
        </div>
      </div>
    
      <!-- Database Design Segment -->
      <div class="experience-details-container database">
        <h2>Database Design</h2>
        <p>Two months</p>
        <br>
        <div class="column right">
          <div class="bars">
            <div class="progress-name"><h4>MySQL</h4></div>
            <div class="progress">
              <div class="progress-in" style="width: 80%;"></div>
              <div class="skill-percent"><span>90%</span></div>
            </div>
          </div>
          </div>
      </div>
      
    </section>
    

  

 <section id="projects">
    <p class="section__text__p1">Browse My Recent</p>
    <h1 class="title">Projects</h1>
    <div class="project-details-container">
        <div class="about-containers">
            <asp:Repeater ID="rptProjects" runat="server">
                <ItemTemplate>
                    <div class="details-container color-container">
                        <div class="article-container">
                            <img src='<%# Eval("ImagePath") %>' alt='<%# Eval("AltText") %>' class="project-img" />
                        </div>
                        <h2 class="experience-sub-title project-title"><%# Eval("Title") %></h2>
                        <div class="btn-container">
                            <button class="btn btn-color-2 project-btn" onclick='<%# "location.href=\"" + Eval("Link") + "\"" %>'>Github</button>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
  </section>
     
      <section id="activities">
    <p class="section__text__p1">To know more</p>
    <h1 class="title">Extracurricular <br />Activities</h1>

    <div class="services__container container grid">
        <asp:Repeater ID="rptActivities" runat="server">
            <ItemTemplate>
                <div class="services__content">
                    <div>
                        <i class="uil uil-browser services__icon"></i>
                        <h3 class="services__title"><%# Eval("Title") %></h3>

                        <div class="services__info">
                            <p class="services__link">Link : <a href='<%# Eval("Link") %>'><strong><%# Eval("LinkTitle") %></strong></a></p>
                            <p class="services__solved">Solved Problems: <%# Eval("SolvedProblems") %></p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</section>

    
    

    <section id="contact">
      <img src="./assets/arrow_top.png" alt="Arrow icon" class="arrow_top"
      onclick="location.href='./#home'">
      <!-- <img
      src="./assets/arrow.png"
      alt="Arrow icon"
      class="arrow_top"
      onclick="location.href='./#home'"
    /> -->
      <p class="scroll__text-top">Top</p>
      <p class="section__text__p1">Get In Touch</p>
      <h1 class="title">Contact Me</h1>
    
      <div class="contact-content">
          <div class="column left">
              <p class="contant_text_inv">For any information, <b>contact me</b></p>
              <div class="icons">
                  <div class="row">
                      <i class="fas fa-user"></i>
                      <div class="info">
                          <div class="sub-title">Sumaiya</div>
                      </div>
                  </div>
                  <div class="row">
                      <i class="fas fa-map-marker-alt"></i>
                      <div class="info">
                          <div class="sub-title">Alinagar , Ashrafabad, Dhaka, Bangladesh</div>
                      </div>
                  </div>
                  <div class="row">
                      <i class="fas fa-envelope"></i>
                      <div class="info">
                          <div class="head"><b>Email</b></div>
                          <div class="sub-title">sumaiya.rahim234@gmail.com</div>
                      </div>
                  </div>
              </div>
          </div>
         <div class="column right">
        <div class="text">Message me</div>
        <form id="contactForm" runat="server">
            <div class="fields">
                <div class="field name">
                    <asp:TextBox ID="txtName" runat="server" placeholder="Name" required></asp:TextBox>
                </div>
                <div class="field email">
                    <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" required></asp:TextBox>
                </div>
            </div>
            <div class="field">
                <asp:TextBox ID="txtSubject" runat="server" placeholder="Subject" required></asp:TextBox>
            </div>
            <div class="field textarea">
                <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Rows="10" placeholder="Message.." required></asp:TextBox>
            </div>
            <div class="btn_container_contact">
                <asp:Button ID="btnSend" runat="server" Text="Send message" CssClass="btn btn-color-1" OnClick="btnSend_Click" />
            </div>
        </form>
    </div>
</div>
    
      <footer>
          <nav class="footer-nav">
              <div class="nav-links-container">
                  <ul class="nav-links">
                    <li><a href="#about">About</a></li>
                    <li><a href="#contact">Contact</a></li>
                    <li><a href="#experience">Experience</a></li>
                    <li><a href="#projects">Projects</a></li>
                    <li><a href="#activities">Extracurricular Activities</a></li>
                  </ul>
              </div>
          </nav>
          <p>Copyright &#169; 2024 Sumaiya Rahim. All Rights Reserved.</p>
      </footer>
    </section>
    
    
  
    <script src="script.js"></script>
    </body>
</html>
