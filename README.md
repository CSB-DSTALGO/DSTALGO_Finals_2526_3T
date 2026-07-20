# DSTALGO Finals 2526-3T

## 📌 Student Submission Instructions

Each group must create and manage their own team branch. Do **not** push directly to the `main` branch.

---

### 1. Branch Naming Convention

Name your team's branch using the following format (use underscores `_` instead of spaces):

```
DSTALGO_<SECTION>_GROUP<#>
```

**Examples:**
* `DSTALGO_FFTIS1_GROUP1`
* `DSTALGO_FFTIS1_GROUP3`
* `DSTALGO_FFTIS2_GROUP1`

---

### 2. Team Workflow Steps

#### Step 1: Configure Your Git Identity (Required for Individual Grading)
Every team member **must** set up their Git name and email on their local machine. This guarantees that Git tracks your individual commits under your name when pushing to your team branch:
```bash
git config --global user.name "Your Full Name"
git config --global user.email "your_github_email@example.com"
```

#### Step 2: Clone the Repository
```bash
git clone https://github.com/CSB-DSTALGO/DSTALGO_Finals_2526_3T.git
cd DSTALGO_Finals_2526_3T
```

#### Step 3: Create and Push Your Team Branch (First Member / Leader)
### ⚠️ Important Reminders: Ensure to replace the branch name with your team's branch format
One team member creates the group branch and publishes it to GitHub:
```bash
git checkout -b DSTALGO_FFTIS2_GROUP1
git push -u origin DSTALGO_FFTIS2_GROUP1
```

#### Step 4: Fetch and Join the Team Branch (Other Team Members)
All other team members pull the remote branch list and switch to the team branch:
```bash
git fetch origin
git checkout DSTALGO_FFTIS2_GROUP1
```

#### Step 5: Daily Work Routine (Stage, Commit & Sync)
Always pull before you start working and before you push to keep everyone's code in sync:

1. **Pull latest team changes:**
   ```bash
   git pull origin DSTALGO_FFTIS2_GROUP1
   ```
2. **Work on your code, then stage and commit:**
   ```bash
   git add .
   git commit -m "Add doubly linked list deletion logic"
   ```
3. **Push your commits to the team branch:**
   ```bash
   git push origin DSTALGO_FFTIS2_GROUP1
   ```

---

### ⚠️ Important Reminders
* **Do not push directly to `main`:** Keep all team work strictly within your group's branch.
* **Individual Accountability:** Individual contributions are automatically tracked per commit and can be viewed under repository **Insights $
ightarrow$ Contributors**.
* **Clean build artifacts:** Ensure `bin/` and `obj/` folders are ignored or cleaned before committing (`dotnet new gitignore`).
