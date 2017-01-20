// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
// TargetFrameworkVersion = 4.6
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices; //HACK: VS not coping EntityFramework.SqlServer.dll;
using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Cts.Venture.Domain;
using System.Threading;
using System.ComponentModel.DataAnnotations;
//using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;

namespace Cts.Venture.Data
{
    public partial class VENTUREDbContext : DbContext, IVENTUREDbContext
    {
        public DbSet<Address> Addresses { get; set; } // Address
        public DbSet<AspnetApplication> AspnetApplications { get; set; } // aspnet_Applications
        public DbSet<AspnetRole> AspnetRoles { get; set; } // aspnet_Roles
        public DbSet<AspnetSchemaVersion> AspnetSchemaVersions { get; set; } // aspnet_SchemaVersions
        public DbSet<AspnetUser> AspnetUsers { get; set; } // aspnet_Users
        public DbSet<ConsensusRatingCategory> ConsensusRatingCategories { get; set; } // ConsensusRatingCategory
        public DbSet<Department> Departments { get; set; } // Department
        public DbSet<FinancialInformation> FinancialInformations { get; set; } // FinancialInformation
        public DbSet<Impact> Impacts { get; set; } // Impact
        public DbSet<Indicator> Indicators { get; set; } // Indicator
        public DbSet<Issue> Issues { get; set; } // Issue
        public DbSet<IssueStatu> IssueStatus { get; set; } // IssueStatus
        public DbSet<IssueType> IssueTypes { get; set; } // IssueType
        public DbSet<LessonLearned> LessonLearneds { get; set; } // LessonLearned
        public DbSet<LessonLearnedType> LessonLearnedTypes { get; set; } // LessonLearnedType
        public DbSet<Lob> Lobs { get; set; } // LOB
        public DbSet<Probability> Probabilities { get; set; } // Probability
        public DbSet<Project> Projects { get; set; } // Project
        public DbSet<ProjectConsensusRating> ProjectConsensusRatings { get; set; } // ProjectConsensusRating
        public DbSet<ProjectGoal> ProjectGoals { get; set; } // ProjectGoal
        public DbSet<ProjectHealth> ProjectHealths { get; set; } // ProjectHealth
        public DbSet<ProjectLevel> ProjectLevels { get; set; } // ProjectLevel
        public DbSet<ProjectMilestone> ProjectMilestones { get; set; } // ProjectMilestone
        public DbSet<ProjectProjectHealth> ProjectProjectHealths { get; set; } // ProjectProjectHealth
        public DbSet<ProjectRating> ProjectRatings { get; set; } // ProjectRating
        public DbSet<ProjectRatingHistory> ProjectRatingHistories { get; set; } // ProjectRatingHistory
        public DbSet<ProjectRatingText> ProjectRatingTexts { get; set; } // ProjectRatingText
        public DbSet<ProjectStandardMilestone> ProjectStandardMilestones { get; set; } // ProjectStandardMilestone
        public DbSet<ProjectStatu> ProjectStatus { get; set; } // ProjectStatus
        public DbSet<ProjectTeam> ProjectTeams { get; set; } // ProjectTeam
        public DbSet<ProjectTeamRole> ProjectTeamRoles { get; set; } // ProjectTeamRole
        public DbSet<Resource> Resources { get; set; } // Resource
        public DbSet<Risk> Risks { get; set; } // Risk
        public DbSet<RiskStatu> RiskStatus { get; set; } // RiskStatus
        public DbSet<Role> Roles { get; set; } // Role
        public DbSet<StandardMilestone> StandardMilestones { get; set; } // StandardMilestone
        public DbSet<State> States { get; set; } // State
        public DbSet<Status> Status { get; set; } // Status
        public DbSet<TeamRole> TeamRoles { get; set; } // TeamRole
        public DbSet<User> Users { get; set; } // User
        
        static VENTUREDbContext()
        {
            System.Data.Entity.Database.SetInitializer<VENTUREDbContext>(null);
        }

        public VENTUREDbContext()
            : base("Name=VENTUREDbContext")
        {
            InitializePartial();
        }

        public VENTUREDbContext(string connectionString) : base(connectionString)
        {
            InitializePartial();
        }

        public VENTUREDbContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model) : base(connectionString, model)
        {
            InitializePartial();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new AspnetApplicationMap());
            modelBuilder.Configurations.Add(new AspnetRoleMap());
            modelBuilder.Configurations.Add(new AspnetSchemaVersionMap());
            modelBuilder.Configurations.Add(new AspnetUserMap());
            modelBuilder.Configurations.Add(new ConsensusRatingCategoryMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new FinancialInformationMap());
            modelBuilder.Configurations.Add(new ImpactMap());
            modelBuilder.Configurations.Add(new IndicatorMap());
            modelBuilder.Configurations.Add(new IssueMap());
            modelBuilder.Configurations.Add(new IssueStatuMap());
            modelBuilder.Configurations.Add(new IssueTypeMap());
            modelBuilder.Configurations.Add(new LessonLearnedMap());
            modelBuilder.Configurations.Add(new LessonLearnedTypeMap());
            modelBuilder.Configurations.Add(new LobMap());
            modelBuilder.Configurations.Add(new ProbabilityMap());
            modelBuilder.Configurations.Add(new ProjectMap());
            modelBuilder.Configurations.Add(new ProjectConsensusRatingMap());
            modelBuilder.Configurations.Add(new ProjectGoalMap());
            modelBuilder.Configurations.Add(new ProjectHealthMap());
            modelBuilder.Configurations.Add(new ProjectLevelMap());
            modelBuilder.Configurations.Add(new ProjectMilestoneMap());
            modelBuilder.Configurations.Add(new ProjectProjectHealthMap());
            modelBuilder.Configurations.Add(new ProjectRatingMap());
            modelBuilder.Configurations.Add(new ProjectRatingHistoryMap());
            modelBuilder.Configurations.Add(new ProjectRatingTextMap());
            modelBuilder.Configurations.Add(new ProjectStandardMilestoneMap());
            modelBuilder.Configurations.Add(new ProjectStatuMap());
            modelBuilder.Configurations.Add(new ProjectTeamMap());
            modelBuilder.Configurations.Add(new ProjectTeamRoleMap());
            modelBuilder.Configurations.Add(new ResourceMap());
            modelBuilder.Configurations.Add(new RiskMap());
            modelBuilder.Configurations.Add(new RiskStatuMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new StandardMilestoneMap());
            modelBuilder.Configurations.Add(new StateMap());
            modelBuilder.Configurations.Add(new StatusMap());
            modelBuilder.Configurations.Add(new TeamRoleMap());
            modelBuilder.Configurations.Add(new UserMap());

            OnModelCreatingPartial(modelBuilder);
        }

        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new AddressMap(schema));
            modelBuilder.Configurations.Add(new AspnetApplicationMap(schema));
            modelBuilder.Configurations.Add(new AspnetRoleMap(schema));
            modelBuilder.Configurations.Add(new AspnetSchemaVersionMap(schema));
            modelBuilder.Configurations.Add(new AspnetUserMap(schema));
            modelBuilder.Configurations.Add(new ConsensusRatingCategoryMap(schema));
            modelBuilder.Configurations.Add(new DepartmentMap(schema));
            modelBuilder.Configurations.Add(new FinancialInformationMap(schema));
            modelBuilder.Configurations.Add(new ImpactMap(schema));
            modelBuilder.Configurations.Add(new IndicatorMap(schema));
            modelBuilder.Configurations.Add(new IssueMap(schema));
            modelBuilder.Configurations.Add(new IssueStatuMap(schema));
            modelBuilder.Configurations.Add(new IssueTypeMap(schema));
            modelBuilder.Configurations.Add(new LessonLearnedMap(schema));
            modelBuilder.Configurations.Add(new LessonLearnedTypeMap(schema));
            modelBuilder.Configurations.Add(new LobMap(schema));
            modelBuilder.Configurations.Add(new ProbabilityMap(schema));
            modelBuilder.Configurations.Add(new ProjectMap(schema));
            modelBuilder.Configurations.Add(new ProjectConsensusRatingMap(schema));
            modelBuilder.Configurations.Add(new ProjectGoalMap(schema));
            modelBuilder.Configurations.Add(new ProjectHealthMap(schema));
            modelBuilder.Configurations.Add(new ProjectLevelMap(schema));
            modelBuilder.Configurations.Add(new ProjectMilestoneMap(schema));
            modelBuilder.Configurations.Add(new ProjectProjectHealthMap(schema));
            modelBuilder.Configurations.Add(new ProjectRatingMap(schema));
            modelBuilder.Configurations.Add(new ProjectRatingHistoryMap(schema));
            modelBuilder.Configurations.Add(new ProjectRatingTextMap(schema));
            modelBuilder.Configurations.Add(new ProjectStandardMilestoneMap(schema));
            modelBuilder.Configurations.Add(new ProjectStatuMap(schema));
            modelBuilder.Configurations.Add(new ProjectTeamMap(schema));
            modelBuilder.Configurations.Add(new ProjectTeamRoleMap(schema));
            modelBuilder.Configurations.Add(new ResourceMap(schema));
            modelBuilder.Configurations.Add(new RiskMap(schema));
            modelBuilder.Configurations.Add(new RiskStatuMap(schema));
            modelBuilder.Configurations.Add(new RoleMap(schema));
            modelBuilder.Configurations.Add(new StandardMilestoneMap(schema));
            modelBuilder.Configurations.Add(new StateMap(schema));
            modelBuilder.Configurations.Add(new StatusMap(schema));
            modelBuilder.Configurations.Add(new TeamRoleMap(schema));
            modelBuilder.Configurations.Add(new UserMap(schema));
            return modelBuilder;
        }

        partial void InitializePartial();
        partial void OnModelCreatingPartial(DbModelBuilder modelBuilder);
    }
}
