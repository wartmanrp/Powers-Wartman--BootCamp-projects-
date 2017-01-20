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
    public interface IVENTUREDbContext : IDisposable
    {
        DbSet<Address> Addresses { get; set; } // Address
        DbSet<AspnetApplication> AspnetApplications { get; set; } // aspnet_Applications
        DbSet<AspnetRole> AspnetRoles { get; set; } // aspnet_Roles
        DbSet<AspnetSchemaVersion> AspnetSchemaVersions { get; set; } // aspnet_SchemaVersions
        DbSet<AspnetUser> AspnetUsers { get; set; } // aspnet_Users
        DbSet<ConsensusRatingCategory> ConsensusRatingCategories { get; set; } // ConsensusRatingCategory
        DbSet<Department> Departments { get; set; } // Department
        DbSet<FinancialInformation> FinancialInformations { get; set; } // FinancialInformation
        DbSet<Impact> Impacts { get; set; } // Impact
        DbSet<Indicator> Indicators { get; set; } // Indicator
        DbSet<Issue> Issues { get; set; } // Issue
        DbSet<IssueStatu> IssueStatus { get; set; } // IssueStatus
        DbSet<IssueType> IssueTypes { get; set; } // IssueType
        DbSet<LessonLearned> LessonLearneds { get; set; } // LessonLearned
        DbSet<LessonLearnedType> LessonLearnedTypes { get; set; } // LessonLearnedType
        DbSet<Lob> Lobs { get; set; } // LOB
        DbSet<Probability> Probabilities { get; set; } // Probability
        DbSet<Project> Projects { get; set; } // Project
        DbSet<ProjectConsensusRating> ProjectConsensusRatings { get; set; } // ProjectConsensusRating
        DbSet<ProjectGoal> ProjectGoals { get; set; } // ProjectGoal
        DbSet<ProjectHealth> ProjectHealths { get; set; } // ProjectHealth
        DbSet<ProjectLevel> ProjectLevels { get; set; } // ProjectLevel
        DbSet<ProjectMilestone> ProjectMilestones { get; set; } // ProjectMilestone
        DbSet<ProjectProjectHealth> ProjectProjectHealths { get; set; } // ProjectProjectHealth
        DbSet<ProjectRating> ProjectRatings { get; set; } // ProjectRating
        DbSet<ProjectRatingHistory> ProjectRatingHistories { get; set; } // ProjectRatingHistory
        DbSet<ProjectRatingText> ProjectRatingTexts { get; set; } // ProjectRatingText
        DbSet<ProjectStandardMilestone> ProjectStandardMilestones { get; set; } // ProjectStandardMilestone
        DbSet<ProjectStatu> ProjectStatus { get; set; } // ProjectStatus
        DbSet<ProjectTeam> ProjectTeams { get; set; } // ProjectTeam
        DbSet<ProjectTeamRole> ProjectTeamRoles { get; set; } // ProjectTeamRole
        DbSet<Resource> Resources { get; set; } // Resource
        DbSet<Risk> Risks { get; set; } // Risk
        DbSet<RiskStatu> RiskStatus { get; set; } // RiskStatus
        DbSet<Role> Roles { get; set; } // Role
        DbSet<StandardMilestone> StandardMilestones { get; set; } // StandardMilestone
        DbSet<State> States { get; set; } // State
        DbSet<Status> Status { get; set; } // Status
        DbSet<TeamRole> TeamRoles { get; set; } // TeamRole
        DbSet<User> Users { get; set; } // User

        int SaveChanges();
        System.Threading.Tasks.Task<int> SaveChangesAsync();
        System.Threading.Tasks.Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }

}
