const expect = require("chai").expect;
const fetchmock = require("fetch-mock");
const fetchapi = require("../fetchapidemo");
const mockdata = [
  {
    id: 8735,
    description: "exercise-7",
    name: "exercise-7",
    name_with_namespace: "stack_csharp_bytelearning / exercise-7",
    path: "exercise-7",
    path_with_namespace: "stack_csharp_bytelearning/exercise-7",
    created_at: "2019-09-04T16:11:19.162+05:30",
    default_branch: "master",
    tag_list: [],
    ssh_url_to_repo:
      "git@gitlab-nht.stackroute.in:stack_csharp_bytelearning/exercise-7.git",
    http_url_to_repo:
      "https://gitlab-nht.stackroute.in/stack_csharp_bytelearning/exercise-7.git",
    web_url:
      "https://gitlab-nht.stackroute.in/stack_csharp_bytelearning/exercise-7",
    readme_url:
      "https://gitlab-nht.stackroute.in/stack_csharp_bytelearning/exercise-7/blob/master/README.md",
    avatar_url: null,
    star_count: 0,
    forks_count: 0,
    last_activity_at: "2019-09-04T16:11:19.162+05:30",
    namespace: {
      id: 511,
      name: "stack_csharp_bytelearning",
      path: "stack_csharp_bytelearning",
      kind: "group",
      full_path: "stack_csharp_bytelearning",
      parent_id: null
    },
    _links: {
      self: "https://gitlab-nht.stackroute.in/api/v4/projects/8735",
      issues: "https://gitlab-nht.stackroute.in/api/v4/projects/8735/issues",
      merge_requests:
        "https://gitlab-nht.stackroute.in/api/v4/projects/8735/merge_requests",
      repo_branches:
        "https://gitlab-nht.stackroute.in/api/v4/projects/8735/repository/branches",
      labels: "https://gitlab-nht.stackroute.in/api/v4/projects/8735/labels",
      events: "https://gitlab-nht.stackroute.in/api/v4/projects/8735/events",
      members: "https://gitlab-nht.stackroute.in/api/v4/projects/8735/members"
    },
    archived: false,
    visibility: "internal",
    resolve_outdated_diff_discussions: false,
    container_registry_enabled: true,
    issues_enabled: true,
    merge_requests_enabled: true,
    wiki_enabled: true,
    jobs_enabled: true,
    snippets_enabled: true,
    shared_runners_enabled: true,
    lfs_enabled: true,
    creator_id: 18,
    import_status: "none",
    open_issues_count: 0,
    public_jobs: true,
    ci_config_path: null,
    shared_with_groups: [],
    only_allow_merge_if_pipeline_succeeds: false,
    request_access_enabled: false,
    only_allow_merge_if_all_discussions_are_resolved: false,
    printing_merge_request_link_enabled: true,
    merge_method: "merge",
    permissions: {
      project_access: null,
      group_access: null
    }
  },
  {
    id: 8694,
    description: "javascript Movie Cruiser Assignment",
    name: "javascript-movie-cruiser-assignment",
    name_with_namespace: "Hitesh Patidar / javascript-movie-cruiser-assignment",
    path: "javascript-movie-cruiser-assignment",
    path_with_namespace: "Hitesh.Patidar/javascript-movie-cruiser-assignment",
    created_at: "2019-09-04T09:12:09.932+05:30",
    default_branch: "master",
    tag_list: [],
    ssh_url_to_repo:
      "git@gitlab-nht.stackroute.in:Hitesh.Patidar/javascript-movie-cruiser-assignment.git",
    http_url_to_repo:
      "https://gitlab-nht.stackroute.in/Hitesh.Patidar/javascript-movie-cruiser-assignment.git",
    web_url:
      "https://gitlab-nht.stackroute.in/Hitesh.Patidar/javascript-movie-cruiser-assignment",
    readme_url:
      "https://gitlab-nht.stackroute.in/Hitesh.Patidar/javascript-movie-cruiser-assignment/blob/master/README.md",
    avatar_url: null,
    star_count: 0,
    forks_count: 0,
    last_activity_at: "2019-09-04T22:08:53.337+05:30",
    namespace: {
      id: 433,
      name: "Hitesh.Patidar",
      path: "Hitesh.Patidar",
      kind: "user",
      full_path: "Hitesh.Patidar",
      parent_id: null
    },
    _links: {
      self: "https://gitlab-nht.stackroute.in/api/v4/projects/8694",
      issues: "https://gitlab-nht.stackroute.in/api/v4/projects/8694/issues",
      merge_requests:
        "https://gitlab-nht.stackroute.in/api/v4/projects/8694/merge_requests",
      repo_branches:
        "https://gitlab-nht.stackroute.in/api/v4/projects/8694/repository/branches",
      labels: "https://gitlab-nht.stackroute.in/api/v4/projects/8694/labels",
      events: "https://gitlab-nht.stackroute.in/api/v4/projects/8694/events",
      members: "https://gitlab-nht.stackroute.in/api/v4/projects/8694/members"
    },
    archived: false,
    visibility: "private",
    owner: {
      id: 345,
      name: "Hitesh Patidar",
      username: "Hitesh.Patidar",
      state: "active",
      avatar_url:
        "https://secure.gravatar.com/avatar/babb6c3cf15f4d83d205f3030d62bd3c?s=80\u0026d=identicon",
      web_url: "https://gitlab-nht.stackroute.in/Hitesh.Patidar"
    },
    resolve_outdated_diff_discussions: false,
    container_registry_enabled: true,
    issues_enabled: true,
    merge_requests_enabled: true,
    wiki_enabled: true,
    jobs_enabled: true,
    snippets_enabled: true,
    shared_runners_enabled: true,
    lfs_enabled: true,
    creator_id: 345,
    forked_from_project: {
      id: 30,
      description: "javascript Movie Cruiser Assignment",
      name: "javascript-movie-cruiser-assignment",
      name_with_namespace: "stack_js / javascript-movie-cruiser-assignment",
      path: "javascript-movie-cruiser-assignment",
      path_with_namespace: "stack_js/javascript-movie-cruiser-assignment",
      created_at: "2019-06-18T10:16:28.038+05:30",
      default_branch: "master",
      tag_list: [],
      ssh_url_to_repo:
        "git@gitlab-nht.stackroute.in:stack_js/javascript-movie-cruiser-assignment.git",
      http_url_to_repo:
        "https://gitlab-nht.stackroute.in/stack_js/javascript-movie-cruiser-assignment.git",
      web_url:
        "https://gitlab-nht.stackroute.in/stack_js/javascript-movie-cruiser-assignment",
      readme_url:
        "https://gitlab-nht.stackroute.in/stack_js/javascript-movie-cruiser-assignment/blob/master/README.md",
      avatar_url: null,
      star_count: 1,
      forks_count: 110,
      last_activity_at: "2019-06-18T13:52:54.229+05:30",
      namespace: {
        id: 28,
        name: "stack_js",
        path: "stack_js",
        kind: "group",
        full_path: "stack_js",
        parent_id: null
      }
    },
    import_status: "finished",
    open_issues_count: 0,
    public_jobs: true,
    ci_config_path: null,
    shared_with_groups: [],
    only_allow_merge_if_pipeline_succeeds: false,
    request_access_enabled: false,
    only_allow_merge_if_all_discussions_are_resolved: false,
    printing_merge_request_link_enabled: true,
    merge_method: "merge",
    permissions: {
      project_access: {
        access_level: 40,
        notification_level: 3
      },
      group_access: null
    }
  },
  {
    id: 8464,
    description: "",
    name: "javascript-basics-assignment",
    name_with_namespace: "Hitesh Patidar / javascript-basics-assignment",
    path: "javascript-basics-assignment",
    path_with_namespace: "Hitesh.Patidar/javascript-basics-assignment",
    created_at: "2019-09-02T11:37:09.119+05:30",
    default_branch: "master",
    tag_list: [],
    ssh_url_to_repo:
      "git@gitlab-nht.stackroute.in:Hitesh.Patidar/javascript-basics-assignment.git",
    http_url_to_repo:
      "https://gitlab-nht.stackroute.in/Hitesh.Patidar/javascript-basics-assignment.git",
    web_url:
      "https://gitlab-nht.stackroute.in/Hitesh.Patidar/javascript-basics-assignment",
    readme_url:
      "https://gitlab-nht.stackroute.in/Hitesh.Patidar/javascript-basics-assignment/blob/master/README.md",
    avatar_url: null,
    star_count: 0,
    forks_count: 0,
    last_activity_at: "2019-09-02T12:40:46.579+05:30",
    namespace: {
      id: 433,
      name: "Hitesh.Patidar",
      path: "Hitesh.Patidar",
      kind: "user",
      full_path: "Hitesh.Patidar",
      parent_id: null
    },
    _links: {
      self: "https://gitlab-nht.stackroute.in/api/v4/projects/8464",
      issues: "https://gitlab-nht.stackroute.in/api/v4/projects/8464/issues",
      merge_requests:
        "https://gitlab-nht.stackroute.in/api/v4/projects/8464/merge_requests",
      repo_branches:
        "https://gitlab-nht.stackroute.in/api/v4/projects/8464/repository/branches",
      labels: "https://gitlab-nht.stackroute.in/api/v4/projects/8464/labels",
      events: "https://gitlab-nht.stackroute.in/api/v4/projects/8464/events",
      members: "https://gitlab-nht.stackroute.in/api/v4/projects/8464/members"
    },
    archived: false,
    visibility: "private",
    owner: {
      id: 345,
      name: "Hitesh Patidar",
      username: "Hitesh.Patidar",
      state: "active",
      avatar_url:
        "https://secure.gravatar.com/avatar/babb6c3cf15f4d83d205f3030d62bd3c?s=80\u0026d=identicon",
      web_url: "https://gitlab-nht.stackroute.in/Hitesh.Patidar"
    },
    resolve_outdated_diff_discussions: false,
    container_registry_enabled: true,
    issues_enabled: true,
    merge_requests_enabled: true,
    wiki_enabled: true,
    jobs_enabled: true,
    snippets_enabled: true,
    shared_runners_enabled: true,
    lfs_enabled: true,
    creator_id: 345,
    forked_from_project: {
      id: 1460,
      description: "",
      name: "javascript-basics-assignment",
      name_with_namespace: "stack_js / javascript-basics-assignment",
      path: "javascript-basics-assignment",
      path_with_namespace: "stack_js/javascript-basics-assignment",
      created_at: "2019-07-04T15:12:59.647+05:30",
      default_branch: "master",
      tag_list: [],
      ssh_url_to_repo:
        "git@gitlab-nht.stackroute.in:stack_js/javascript-basics-assignment.git",
      http_url_to_repo:
        "https://gitlab-nht.stackroute.in/stack_js/javascript-basics-assignment.git",
      web_url:
        "https://gitlab-nht.stackroute.in/stack_js/javascript-basics-assignment",
      readme_url:
        "https://gitlab-nht.stackroute.in/stack_js/javascript-basics-assignment/blob/master/README.md",
      avatar_url: null,
      star_count: 0,
      forks_count: 125,
      last_activity_at: "2019-08-19T10:53:38.404+05:30",
      namespace: {
        id: 28,
        name: "stack_js",
        path: "stack_js",
        kind: "group",
        full_path: "stack_js",
        parent_id: null
      }
    },
    import_status: "finished",
    open_issues_count: 0,
    public_jobs: true,
    ci_config_path: null,
    shared_with_groups: [],
    only_allow_merge_if_pipeline_succeeds: false,
    request_access_enabled: false,
    only_allow_merge_if_all_discussions_are_resolved: false,
    printing_merge_request_link_enabled: true,
    merge_method: "merge",
    permissions: {
      project_access: {
        access_level: 40,
        notification_level: 3
      },
      group_access: null
    }
  },
  {
    id: 8055,
    description: "responsive-webpage-assigment  using Bootstrap",
    name: "responsive-webpage-assigment ",
    name_with_namespace: "Hitesh Patidar / responsive-webpage-assigment ",
    path: "responsive-webpage-assigment-",
    path_with_namespace: "Hitesh.Patidar/responsive-webpage-assigment-",
    created_at: "2019-08-29T10:33:15.603+05:30",
    default_branch: "master",
    tag_list: [],
    ssh_url_to_repo:
      "git@gitlab-nht.stackroute.in:Hitesh.Patidar/responsive-webpage-assigment-.git",
    http_url_to_repo:
      "https://gitlab-nht.stackroute.in/Hitesh.Patidar/responsive-webpage-assigment-.git",
    web_url:
      "https://gitlab-nht.stackroute.in/Hitesh.Patidar/responsive-webpage-assigment-",
    readme_url: null,
    avatar_url: null,
    star_count: 0,
    forks_count: 0,
    last_activity_at: "2019-08-29T10:33:15.603+05:30",
    namespace: {
      id: 433,
      name: "Hitesh.Patidar",
      path: "Hitesh.Patidar",
      kind: "user",
      full_path: "Hitesh.Patidar",
      parent_id: null
    },
    _links: {
      self: "https://gitlab-nht.stackroute.in/api/v4/projects/8055",
      issues: "https://gitlab-nht.stackroute.in/api/v4/projects/8055/issues",
      merge_requests:
        "https://gitlab-nht.stackroute.in/api/v4/projects/8055/merge_requests",
      repo_branches:
        "https://gitlab-nht.stackroute.in/api/v4/projects/8055/repository/branches",
      labels: "https://gitlab-nht.stackroute.in/api/v4/projects/8055/labels",
      events: "https://gitlab-nht.stackroute.in/api/v4/projects/8055/events",
      members: "https://gitlab-nht.stackroute.in/api/v4/projects/8055/members"
    },
    archived: false,
    visibility: "private",
    owner: {
      id: 345,
      name: "Hitesh Patidar",
      username: "Hitesh.Patidar",
      state: "active",
      avatar_url:
        "https://secure.gravatar.com/avatar/babb6c3cf15f4d83d205f3030d62bd3c?s=80\u0026d=identicon",
      web_url: "https://gitlab-nht.stackroute.in/Hitesh.Patidar"
    },
    resolve_outdated_diff_discussions: false,
    container_registry_enabled: true,
    issues_enabled: true,
    merge_requests_enabled: true,
    wiki_enabled: true,
    jobs_enabled: true,
    snippets_enabled: true,
    shared_runners_enabled: true,
    lfs_enabled: true,
    creator_id: 345,
    forked_from_project: {
      id: 32,
      description: "responsive-webpage-assigment  using Bootstrap",
      name: "responsive-webpage-assigment ",
      name_with_namespace: "stack_htmlcss / responsive-webpage-assigment ",
      path: "responsive-webpage-assigment-",
      path_with_namespace: "stack_htmlcss/responsive-webpage-assigment-",
      created_at: "2019-06-18T10:24:09.643+05:30",
      default_branch: "master",
      tag_list: [],
      ssh_url_to_repo:
        "git@gitlab-nht.stackroute.in:stack_htmlcss/responsive-webpage-assigment-.git",
      http_url_to_repo:
        "https://gitlab-nht.stackroute.in/stack_htmlcss/responsive-webpage-assigment-.git",
      web_url:
        "https://gitlab-nht.stackroute.in/stack_htmlcss/responsive-webpage-assigment-",
      readme_url: null,
      avatar_url: null,
      star_count: 0,
      forks_count: 235,
      last_activity_at: "2019-07-10T14:55:37.839+05:30",
      namespace: {
        id: 29,
        name: "stack_htmlcss",
        path: "stack_htmlcss",
        kind: "group",
        full_path: "stack_htmlcss",
        parent_id: null
      }
    },
    import_status: "finished",
    open_issues_count: 0,
    public_jobs: true,
    ci_config_path: null,
    shared_with_groups: [],
    only_allow_merge_if_pipeline_succeeds: false,
    request_access_enabled: false,
    only_allow_merge_if_all_discussions_are_resolved: false,
    printing_merge_request_link_enabled: true,
    merge_method: "merge",
    permissions: {
      project_access: {
        access_level: 40,
        notification_level: 3
      },
      group_access: null
    }
  },
  {
    id: 7841,
    description: "",
    name: "training",
    name_with_namespace: "Hitesh Patidar / training",
    path: "training",
    path_with_namespace: "Hitesh.Patidar/training",
    created_at: "2019-08-28T09:37:30.602+05:30",
    default_branch: "master",
    tag_list: [],
    ssh_url_to_repo: "git@gitlab-nht.stackroute.in:Hitesh.Patidar/training.git",
    http_url_to_repo:
      "https://gitlab-nht.stackroute.in/Hitesh.Patidar/training.git",
    web_url: "https://gitlab-nht.stackroute.in/Hitesh.Patidar/training",
    readme_url: null,
    avatar_url: null,
    star_count: 0,
    forks_count: 0,
    last_activity_at: "2019-09-02T09:08:56.680+05:30",
    namespace: {
      id: 433,
      name: "Hitesh.Patidar",
      path: "Hitesh.Patidar",
      kind: "user",
      full_path: "Hitesh.Patidar",
      parent_id: null
    },
    _links: {
      self: "https://gitlab-nht.stackroute.in/api/v4/projects/7841",
      issues: "https://gitlab-nht.stackroute.in/api/v4/projects/7841/issues",
      merge_requests:
        "https://gitlab-nht.stackroute.in/api/v4/projects/7841/merge_requests",
      repo_branches:
        "https://gitlab-nht.stackroute.in/api/v4/projects/7841/repository/branches",
      labels: "https://gitlab-nht.stackroute.in/api/v4/projects/7841/labels",
      events: "https://gitlab-nht.stackroute.in/api/v4/projects/7841/events",
      members: "https://gitlab-nht.stackroute.in/api/v4/projects/7841/members"
    },
    archived: false,
    visibility: "private",
    owner: {
      id: 345,
      name: "Hitesh Patidar",
      username: "Hitesh.Patidar",
      state: "active",
      avatar_url:
        "https://secure.gravatar.com/avatar/babb6c3cf15f4d83d205f3030d62bd3c?s=80\u0026d=identicon",
      web_url: "https://gitlab-nht.stackroute.in/Hitesh.Patidar"
    },
    resolve_outdated_diff_discussions: false,
    container_registry_enabled: true,
    issues_enabled: true,
    merge_requests_enabled: true,
    wiki_enabled: true,
    jobs_enabled: true,
    snippets_enabled: true,
    shared_runners_enabled: true,
    lfs_enabled: true,
    creator_id: 345,
    import_status: "none",
    open_issues_count: 0,
    public_jobs: true,
    ci_config_path: null,
    shared_with_groups: [],
    only_allow_merge_if_pipeline_succeeds: false,
    request_access_enabled: false,
    only_allow_merge_if_all_discussions_are_resolved: false,
    printing_merge_request_link_enabled: true,
    merge_method: "merge",
    permissions: {
      project_access: {
        access_level: 40,
        notification_level: 3
      },
      group_access: null
    }
  },
  {
    id: 7827,
    description: "",
    name: "Training1",
    name_with_namespace: "Hitesh Patidar / Training1",
    path: "training1",
    path_with_namespace: "Hitesh.Patidar/training1",
    created_at: "2019-08-28T09:23:41.947+05:30",
    default_branch: "master",
    tag_list: [],
    ssh_url_to_repo:
      "git@gitlab-nht.stackroute.in:Hitesh.Patidar/training1.git",
    http_url_to_repo:
      "https://gitlab-nht.stackroute.in/Hitesh.Patidar/training1.git",
    web_url: "https://gitlab-nht.stackroute.in/Hitesh.Patidar/training1",
    readme_url: null,
    avatar_url: null,
    star_count: 0,
    forks_count: 0,
    last_activity_at: "2019-08-28T09:23:41.947+05:30",
    namespace: {
      id: 433,
      name: "Hitesh.Patidar",
      path: "Hitesh.Patidar",
      kind: "user",
      full_path: "Hitesh.Patidar",
      parent_id: null
    },
    _links: {
      self: "https://gitlab-nht.stackroute.in/api/v4/projects/7827",
      issues: "https://gitlab-nht.stackroute.in/api/v4/projects/7827/issues",
      merge_requests:
        "https://gitlab-nht.stackroute.in/api/v4/projects/7827/merge_requests",
      repo_branches:
        "https://gitlab-nht.stackroute.in/api/v4/projects/7827/repository/branches",
      labels: "https://gitlab-nht.stackroute.in/api/v4/projects/7827/labels",
      events: "https://gitlab-nht.stackroute.in/api/v4/projects/7827/events",
      members: "https://gitlab-nht.stackroute.in/api/v4/projects/7827/members"
    },
    archived: false,
    visibility: "private",
    owner: {
      id: 345,
      name: "Hitesh Patidar",
      username: "Hitesh.Patidar",
      state: "active",
      avatar_url:
        "https://secure.gravatar.com/avatar/babb6c3cf15f4d83d205f3030d62bd3c?s=80\u0026d=identicon",
      web_url: "https://gitlab-nht.stackroute.in/Hitesh.Patidar"
    },
    resolve_outdated_diff_discussions: false,
    container_registry_enabled: true,
    issues_enabled: true,
    merge_requests_enabled: true,
    wiki_enabled: true,
    jobs_enabled: true,
    snippets_enabled: true,
    shared_runners_enabled: true,
    lfs_enabled: true,
    creator_id: 345,
    import_status: "none",
    open_issues_count: 0,
    public_jobs: true,
    ci_config_path: null,
    shared_with_groups: [],
    only_allow_merge_if_pipeline_succeeds: false,
    request_access_enabled: false,
    only_allow_merge_if_all_discussions_are_resolved: false,
    printing_merge_request_link_enabled: true,
    merge_method: "merge",
    permissions: {
      project_access: {
        access_level: 40,
        notification_level: 3
      },
      group_access: null
    }
  },
  {
    id: 7107,
    description: "",
    name: "tour-of-heroes",
    name_with_namespace: "deepan.ramalingam / tour-of-heroes",
    path: "tour-of-heroes",
    path_with_namespace: "deepan.ramalingam/tour-of-heroes",
    created_at: "2019-08-21T17:36:38.378+05:30",
    default_branch: null,
    tag_list: [],
    ssh_url_to_repo:
      "git@gitlab-nht.stackroute.in:deepan.ramalingam/tour-of-heroes.git",
    http_url_to_repo:
      "https://gitlab-nht.stackroute.in/deepan.ramalingam/tour-of-heroes.git",
    web_url:
      "https://gitlab-nht.stackroute.in/deepan.ramalingam/tour-of-heroes",
    readme_url: null,
    avatar_url: null,
    star_count: 0,
    forks_count: 0,
    last_activity_at: "2019-08-21T17:36:38.378+05:30",
    namespace: {
      id: 239,
      name: "deepan.ramalingam",
      path: "deepan.ramalingam",
      kind: "user",
      full_path: "deepan.ramalingam",
      parent_id: null
    },
    _links: {
      self: "https://gitlab-nht.stackroute.in/api/v4/projects/7107",
      issues: "https://gitlab-nht.stackroute.in/api/v4/projects/7107/issues",
      merge_requests:
        "https://gitlab-nht.stackroute.in/api/v4/projects/7107/merge_requests",
      repo_branches:
        "https://gitlab-nht.stackroute.in/api/v4/projects/7107/repository/branches",
      labels: "https://gitlab-nht.stackroute.in/api/v4/projects/7107/labels",
      events: "https://gitlab-nht.stackroute.in/api/v4/projects/7107/events",
      members: "https://gitlab-nht.stackroute.in/api/v4/projects/7107/members"
    },
    archived: false,
    visibility: "internal",
    owner: {
      id: 184,
      name: "deepan.ramalingam",
      username: "deepan.ramalingam",
      state: "active",
      avatar_url:
        "https://secure.gravatar.com/avatar/8688def2166881debd43ddbd411616d2?s=80\u0026d=identicon",
      web_url: "https://gitlab-nht.stackroute.in/deepan.ramalingam"
    },
    resolve_outdated_diff_discussions: false,
    container_registry_enabled: true,
    issues_enabled: true,
    merge_requests_enabled: true,
    wiki_enabled: true,
    jobs_enabled: true,
    snippets_enabled: true,
    shared_runners_enabled: true,
    lfs_enabled: true,
    creator_id: 184,
    import_status: "none",
    open_issues_count: 0,
    public_jobs: true,
    ci_config_path: null,
    shared_with_groups: [],
    only_allow_merge_if_pipeline_succeeds: false,
    request_access_enabled: false,
    only_allow_merge_if_all_discussions_are_resolved: false,
    printing_merge_request_link_enabled: true,
    merge_method: "merge",
    permissions: {
      project_access: null,
      group_access: null
    }
  },
  {
    id: 6810,
    description: "",
    name: "calculatorWS-FunctionalTesting-SoapUi",
    name_with_namespace:
      "deepan.ramalingam / calculatorWS-FunctionalTesting-SoapUi",
    path: "calculatorws-functionaltesting-soapui",
    path_with_namespace:
      "deepan.ramalingam/calculatorws-functionaltesting-soapui",
    created_at: "2019-08-20T09:29:14.816+05:30",
    default_branch: "master",
    tag_list: [],
    ssh_url_to_repo:
      "git@gitlab-nht.stackroute.in:deepan.ramalingam/calculatorws-functionaltesting-soapui.git",
    http_url_to_repo:
      "https://gitlab-nht.stackroute.in/deepan.ramalingam/calculatorws-functionaltesting-soapui.git",
    web_url:
      "https://gitlab-nht.stackroute.in/deepan.ramalingam/calculatorws-functionaltesting-soapui",
    readme_url: null,
    avatar_url: null,
    star_count: 0,
    forks_count: 0,
    last_activity_at: "2019-08-20T09:29:14.816+05:30",
    namespace: {
      id: 239,
      name: "deepan.ramalingam",
      path: "deepan.ramalingam",
      kind: "user",
      full_path: "deepan.ramalingam",
      parent_id: null
    },
    _links: {
      self: "https://gitlab-nht.stackroute.in/api/v4/projects/6810",
      issues: "https://gitlab-nht.stackroute.in/api/v4/projects/6810/issues",
      merge_requests:
        "https://gitlab-nht.stackroute.in/api/v4/projects/6810/merge_requests",
      repo_branches:
        "https://gitlab-nht.stackroute.in/api/v4/projects/6810/repository/branches",
      labels: "https://gitlab-nht.stackroute.in/api/v4/projects/6810/labels",
      events: "https://gitlab-nht.stackroute.in/api/v4/projects/6810/events",
      members: "https://gitlab-nht.stackroute.in/api/v4/projects/6810/members"
    },
    archived: false,
    visibility: "internal",
    owner: {
      id: 184,
      name: "deepan.ramalingam",
      username: "deepan.ramalingam",
      state: "active",
      avatar_url:
        "https://secure.gravatar.com/avatar/8688def2166881debd43ddbd411616d2?s=80\u0026d=identicon",
      web_url: "https://gitlab-nht.stackroute.in/deepan.ramalingam"
    },
    resolve_outdated_diff_discussions: false,
    container_registry_enabled: true,
    issues_enabled: true,
    merge_requests_enabled: true,
    wiki_enabled: true,
    jobs_enabled: true,
    snippets_enabled: true,
    shared_runners_enabled: true,
    lfs_enabled: true,
    creator_id: 184,
    import_status: "none",
    open_issues_count: 0,
    public_jobs: true,
    ci_config_path: null,
    shared_with_groups: [],
    only_allow_merge_if_pipeline_succeeds: false,
    request_access_enabled: false,
    only_allow_merge_if_all_discussions_are_resolved: false,
    printing_merge_request_link_enabled: true,
    merge_method: "merge",
    permissions: {
      project_access: null,
      group_access: null
    }
  },
  {
    id: 6806,
    description: "",
    name: "calculator-soap-WebService",
    name_with_namespace: "deepan.ramalingam / calculator-soap-WebService",
    path: "calculator-soap-webservice",
    path_with_namespace: "deepan.ramalingam/calculator-soap-webservice",
    created_at: "2019-08-20T09:22:17.600+05:30",
    default_branch: "master",
    tag_list: [],
    ssh_url_to_repo:
      "git@gitlab-nht.stackroute.in:deepan.ramalingam/calculator-soap-webservice.git",
    http_url_to_repo:
      "https://gitlab-nht.stackroute.in/deepan.ramalingam/calculator-soap-webservice.git",
    web_url:
      "https://gitlab-nht.stackroute.in/deepan.ramalingam/calculator-soap-webservice",
    readme_url: null,
    avatar_url: null,
    star_count: 0,
    forks_count: 0,
    last_activity_at: "2019-08-20T09:22:17.600+05:30",
    namespace: {
      id: 239,
      name: "deepan.ramalingam",
      path: "deepan.ramalingam",
      kind: "user",
      full_path: "deepan.ramalingam",
      parent_id: null
    },
    _links: {
      self: "https://gitlab-nht.stackroute.in/api/v4/projects/6806",
      issues: "https://gitlab-nht.stackroute.in/api/v4/projects/6806/issues",
      merge_requests:
        "https://gitlab-nht.stackroute.in/api/v4/projects/6806/merge_requests",
      repo_branches:
        "https://gitlab-nht.stackroute.in/api/v4/projects/6806/repository/branches",
      labels: "https://gitlab-nht.stackroute.in/api/v4/projects/6806/labels",
      events: "https://gitlab-nht.stackroute.in/api/v4/projects/6806/events",
      members: "https://gitlab-nht.stackroute.in/api/v4/projects/6806/members"
    },
    archived: false,
    visibility: "internal",
    owner: {
      id: 184,
      name: "deepan.ramalingam",
      username: "deepan.ramalingam",
      state: "active",
      avatar_url:
        "https://secure.gravatar.com/avatar/8688def2166881debd43ddbd411616d2?s=80\u0026d=identicon",
      web_url: "https://gitlab-nht.stackroute.in/deepan.ramalingam"
    },
    resolve_outdated_diff_discussions: false,
    container_registry_enabled: true,
    issues_enabled: true,
    merge_requests_enabled: true,
    wiki_enabled: true,
    jobs_enabled: true,
    snippets_enabled: true,
    shared_runners_enabled: true,
    lfs_enabled: true,
    creator_id: 184,
    import_status: "none",
    open_issues_count: 0,
    public_jobs: true,
    ci_config_path: null,
    shared_with_groups: [],
    only_allow_merge_if_pipeline_succeeds: false,
    request_access_enabled: false,
    only_allow_merge_if_all_discussions_are_resolved: false,
    printing_merge_request_link_enabled: true,
    merge_method: "merge",
    permissions: {
      project_access: null,
      group_access: null
    }
  },
  {
    id: 4948,
    description: "KeepNote-RDBMS-Assignment-boilerplate ",
    name: "KeepNote-RDBMS-Assignment-boilerplate ",
    name_with_namespace:
      "stack_dotnet_keep  / KeepNote-RDBMS-Assignment-boilerplate ",
    path: "keepnote-rdbms-assignment-boilerplate-",
    path_with_namespace:
      "stack_dotnet_keep/keepnote-rdbms-assignment-boilerplate-",
    created_at: "2019-08-06T16:09:11.496+05:30",
    default_branch: "master",
    tag_list: [],
    ssh_url_to_repo:
      "git@gitlab-nht.stackroute.in:stack_dotnet_keep/keepnote-rdbms-assignment-boilerplate-.git",
    http_url_to_repo:
      "https://gitlab-nht.stackroute.in/stack_dotnet_keep/keepnote-rdbms-assignment-boilerplate-.git",
    web_url:
      "https://gitlab-nht.stackroute.in/stack_dotnet_keep/keepnote-rdbms-assignment-boilerplate-",
    readme_url:
      "https://gitlab-nht.stackroute.in/stack_dotnet_keep/keepnote-rdbms-assignment-boilerplate-/blob/master/README.md",
    avatar_url: null,
    star_count: 0,
    forks_count: 29,
    last_activity_at: "2019-08-06T16:09:11.496+05:30",
    namespace: {
      id: 333,
      name: "stack_dotnet_keep ",
      path: "stack_dotnet_keep",
      kind: "group",
      full_path: "stack_dotnet_keep",
      parent_id: null
    },
    _links: {
      self: "https://gitlab-nht.stackroute.in/api/v4/projects/4948",
      issues: "https://gitlab-nht.stackroute.in/api/v4/projects/4948/issues",
      merge_requests:
        "https://gitlab-nht.stackroute.in/api/v4/projects/4948/merge_requests",
      repo_branches:
        "https://gitlab-nht.stackroute.in/api/v4/projects/4948/repository/branches",
      labels: "https://gitlab-nht.stackroute.in/api/v4/projects/4948/labels",
      events: "https://gitlab-nht.stackroute.in/api/v4/projects/4948/events",
      members: "https://gitlab-nht.stackroute.in/api/v4/projects/4948/members"
    },
    archived: false,
    visibility: "internal",
    resolve_outdated_diff_discussions: false,
    container_registry_enabled: true,
    issues_enabled: true,
    merge_requests_enabled: true,
    wiki_enabled: true,
    jobs_enabled: true,
    snippets_enabled: true,
    shared_runners_enabled: true,
    lfs_enabled: true,
    creator_id: 18,
    import_status: "none",
    open_issues_count: 0,
    public_jobs: true,
    ci_config_path: null,
    shared_with_groups: [],
    only_allow_merge_if_pipeline_succeeds: false,
    request_access_enabled: false,
    only_allow_merge_if_all_discussions_are_resolved: false,
    printing_merge_request_link_enabled: true,
    merge_method: "merge",
    permissions: {
      project_access: null,
      group_access: null
    }
  },
  {
    id: 4530,
    description: "",
    name: "spring-rest_demos",
    name_with_namespace: "java2_blr_mg / spring / spring-rest_demos",
    path: "spring-rest_demos",
    path_with_namespace: "java_ghouse/spring/spring-rest_demos",
    created_at: "2019-08-01T21:49:22.874+05:30",
    default_branch: "master",
    tag_list: [],
    ssh_url_to_repo:
      "git@gitlab-nht.stackroute.in:java_ghouse/spring/spring-rest_demos.git",
    http_url_to_repo:
      "https://gitlab-nht.stackroute.in/java_ghouse/spring/spring-rest_demos.git",
    web_url:
      "https://gitlab-nht.stackroute.in/java_ghouse/spring/spring-rest_demos",
    readme_url: null,
    avatar_url: null,
    star_count: 0,
    forks_count: 8,
    last_activity_at: "2019-08-28T14:29:20.299+05:30",
    namespace: {
      id: 331,
      name: "spring",
      path: "spring",
      kind: "group",
      full_path: "java_ghouse/spring",
      parent_id: 237
    },
    _links: {
      self: "https://gitlab-nht.stackroute.in/api/v4/projects/4530",
      issues: "https://gitlab-nht.stackroute.in/api/v4/projects/4530/issues",
      merge_requests:
        "https://gitlab-nht.stackroute.in/api/v4/projects/4530/merge_requests",
      repo_branches:
        "https://gitlab-nht.stackroute.in/api/v4/projects/4530/repository/branches",
      labels: "https://gitlab-nht.stackroute.in/api/v4/projects/4530/labels",
      events: "https://gitlab-nht.stackroute.in/api/v4/projects/4530/events",
      members: "https://gitlab-nht.stackroute.in/api/v4/projects/4530/members"
    },
    archived: false,
    visibility: "internal",
    resolve_outdated_diff_discussions: false,
    container_registry_enabled: true,
    issues_enabled: true,
    merge_requests_enabled: true,
    wiki_enabled: true,
    jobs_enabled: true,
    snippets_enabled: true,
    shared_runners_enabled: true,
    lfs_enabled: true,
    creator_id: 11,
    import_status: "none",
    open_issues_count: 0,
    public_jobs: true,
    ci_config_path: null,
    shared_with_groups: [],
    only_allow_merge_if_pipeline_succeeds: false,
    request_access_enabled: false,
    only_allow_merge_if_all_discussions_are_resolved: false,
    printing_merge_request_link_enabled: true,
    merge_method: "merge",
    permissions: {
      project_access: null,
      group_access: null
    }
  },
  {
    id: 4529,
    description: "",
    name: "spring_boot_demos",
    name_with_namespace: "java2_blr_mg / spring / spring_boot_demos",
    path: "spring_boot_demos",
    path_with_namespace: "java_ghouse/spring/spring_boot_demos",
    created_at: "2019-08-01T21:48:02.347+05:30",
    default_branch: null,
    tag_list: [],
    ssh_url_to_repo:
      "git@gitlab-nht.stackroute.in:java_ghouse/spring/spring_boot_demos.git",
    http_url_to_repo:
      "https://gitlab-nht.stackroute.in/java_ghouse/spring/spring_boot_demos.git",
    web_url:
      "https://gitlab-nht.stackroute.in/java_ghouse/spring/spring_boot_demos",
    readme_url: null,
    avatar_url: null,
    star_count: 0,
    forks_count: 0,
    last_activity_at: "2019-08-01T21:48:02.347+05:30",
    namespace: {
      id: 331,
      name: "spring",
      path: "spring",
      kind: "group",
      full_path: "java_ghouse/spring",
      parent_id: 237
    },
    _links: {
      self: "https://gitlab-nht.stackroute.in/api/v4/projects/4529",
      issues: "https://gitlab-nht.stackroute.in/api/v4/projects/4529/issues",
      merge_requests:
        "https://gitlab-nht.stackroute.in/api/v4/projects/4529/merge_requests",
      repo_branches:
        "https://gitlab-nht.stackroute.in/api/v4/projects/4529/repository/branches",
      labels: "https://gitlab-nht.stackroute.in/api/v4/projects/4529/labels",
      events: "https://gitlab-nht.stackroute.in/api/v4/projects/4529/events",
      members: "https://gitlab-nht.stackroute.in/api/v4/projects/4529/members"
    },
    archived: false,
    visibility: "internal",
    resolve_outdated_diff_discussions: false,
    container_registry_enabled: true,
    issues_enabled: true,
    merge_requests_enabled: true,
    wiki_enabled: true,
    jobs_enabled: true,
    snippets_enabled: true,
    shared_runners_enabled: true,
    lfs_enabled: true,
    creator_id: 11,
    import_status: "none",
    open_issues_count: 0,
    public_jobs: true,
    ci_config_path: null,
    shared_with_groups: [],
    only_allow_merge_if_pipeline_succeeds: false,
    request_access_enabled: false,
    only_allow_merge_if_all_discussions_are_resolved: false,
    printing_merge_request_link_enabled: true,
    merge_method: "merge",
    permissions: {
      project_access: null,
      group_access: null
    }
  },
  {
    id: 4528,
    description: "",
    name: "spring_demos",
    name_with_namespace: "java2_blr_mg / spring / spring_demos",
    path: "spring_demos",
    path_with_namespace: "java_ghouse/spring/spring_demos",
    created_at: "2019-08-01T21:47:41.054+05:30",
    default_branch: "master",
    tag_list: [],
    ssh_url_to_repo:
      "git@gitlab-nht.stackroute.in:java_ghouse/spring/spring_demos.git",
    http_url_to_repo:
      "https://gitlab-nht.stackroute.in/java_ghouse/spring/spring_demos.git",
    web_url: "https://gitlab-nht.stackroute.in/java_ghouse/spring/spring_demos",
    readme_url: null,
    avatar_url: null,
    star_count: 0,
    forks_count: 3,
    last_activity_at: "2019-08-07T11:52:57.066+05:30",
    namespace: {
      id: 331,
      name: "spring",
      path: "spring",
      kind: "group",
      full_path: "java_ghouse/spring",
      parent_id: 237
    },
    _links: {
      self: "https://gitlab-nht.stackroute.in/api/v4/projects/4528",
      issues: "https://gitlab-nht.stackroute.in/api/v4/projects/4528/issues",
      merge_requests:
        "https://gitlab-nht.stackroute.in/api/v4/projects/4528/merge_requests",
      repo_branches:
        "https://gitlab-nht.stackroute.in/api/v4/projects/4528/repository/branches",
      labels: "https://gitlab-nht.stackroute.in/api/v4/projects/4528/labels",
      events: "https://gitlab-nht.stackroute.in/api/v4/projects/4528/events",
      members: "https://gitlab-nht.stackroute.in/api/v4/projects/4528/members"
    },
    archived: false,
    visibility: "internal",
    resolve_outdated_diff_discussions: false,
    container_registry_enabled: true,
    issues_enabled: true,
    merge_requests_enabled: true,
    wiki_enabled: true,
    jobs_enabled: true,
    snippets_enabled: true,
    shared_runners_enabled: true,
    lfs_enabled: true,
    creator_id: 11,
    import_status: "none",
    open_issues_count: 0,
    public_jobs: true,
    ci_config_path: null,
    shared_with_groups: [],
    only_allow_merge_if_pipeline_succeeds: false,
    request_access_enabled: false,
    only_allow_merge_if_all_discussions_are_resolved: false,
    printing_merge_request_link_enabled: true,
    merge_method: "merge",
    permissions: {
      project_access: null,
      group_access: null
    }
  },
  {
    id: 3136,
    description: "",
    name: "demo02",
    name_with_namespace: "d.duraivelan / demo02",
    path: "demo02",
    path_with_namespace: "d.duraivelan/demo02",
    created_at: "2019-07-22T10:43:01.386+05:30",
    default_branch: null,
    tag_list: [],
    ssh_url_to_repo: "git@gitlab-nht.stackroute.in:d.duraivelan/demo02.git",
    http_url_to_repo:
      "https://gitlab-nht.stackroute.in/d.duraivelan/demo02.git",
    web_url: "https://gitlab-nht.stackroute.in/d.duraivelan/demo02",
    readme_url: null,
    avatar_url: null,
    star_count: 0,
    forks_count: 0,
    last_activity_at: "2019-07-22T10:43:01.386+05:30",
    namespace: {
      id: 243,
      name: "d.duraivelan",
      path: "d.duraivelan",
      kind: "user",
      full_path: "d.duraivelan",
      parent_id: null
    },
    _links: {
      self: "https://gitlab-nht.stackroute.in/api/v4/projects/3136",
      issues: "https://gitlab-nht.stackroute.in/api/v4/projects/3136/issues",
      merge_requests:
        "https://gitlab-nht.stackroute.in/api/v4/projects/3136/merge_requests",
      repo_branches:
        "https://gitlab-nht.stackroute.in/api/v4/projects/3136/repository/branches",
      labels: "https://gitlab-nht.stackroute.in/api/v4/projects/3136/labels",
      events: "https://gitlab-nht.stackroute.in/api/v4/projects/3136/events",
      members: "https://gitlab-nht.stackroute.in/api/v4/projects/3136/members"
    },
    archived: false,
    visibility: "internal",
    owner: {
      id: 185,
      name: "d.duraivelan",
      username: "d.duraivelan",
      state: "active",
      avatar_url:
        "https://secure.gravatar.com/avatar/49f28846189de146b203c6ef88d6454a?s=80\u0026d=identicon",
      web_url: "https://gitlab-nht.stackroute.in/d.duraivelan"
    },
    resolve_outdated_diff_discussions: false,
    container_registry_enabled: true,
    issues_enabled: true,
    merge_requests_enabled: true,
    wiki_enabled: true,
    jobs_enabled: true,
    snippets_enabled: true,
    shared_runners_enabled: true,
    lfs_enabled: true,
    creator_id: 185,
    import_status: "none",
    open_issues_count: 0,
    public_jobs: true,
    ci_config_path: null,
    shared_with_groups: [],
    only_allow_merge_if_pipeline_succeeds: false,
    request_access_enabled: false,
    only_allow_merge_if_all_discussions_are_resolved: false,
    printing_merge_request_link_enabled: true,
    merge_method: "merge",
    permissions: {
      project_access: null,
      group_access: null
    }
  },
  {
    id: 3011,
    description: "",
    name: "routing-jwt-demo",
    name_with_namespace: "nht-wave2-qe-testing / routing-jwt-demo",
    path: "routing-jwt-demo",
    path_with_namespace: "nht-wave2-qe-testing/routing-jwt-demo",
    created_at: "2019-07-19T12:26:56.662+05:30",
    default_branch: "master",
    tag_list: [],
    ssh_url_to_repo:
      "git@gitlab-nht.stackroute.in:nht-wave2-qe-testing/routing-jwt-demo.git",
    http_url_to_repo:
      "https://gitlab-nht.stackroute.in/nht-wave2-qe-testing/routing-jwt-demo.git",
    web_url:
      "https://gitlab-nht.stackroute.in/nht-wave2-qe-testing/routing-jwt-demo",
    readme_url:
      "https://gitlab-nht.stackroute.in/nht-wave2-qe-testing/routing-jwt-demo/blob/master/README.md",
    avatar_url: null,
    star_count: 0,
    forks_count: 7,
    last_activity_at: "2019-07-19T17:41:30.709+05:30",
    namespace: {
      id: 301,
      name: "nht-wave2-qe-testing",
      path: "nht-wave2-qe-testing",
      kind: "group",
      full_path: "nht-wave2-qe-testing",
      parent_id: null
    },
    _links: {
      self: "https://gitlab-nht.stackroute.in/api/v4/projects/3011",
      issues: "https://gitlab-nht.stackroute.in/api/v4/projects/3011/issues",
      merge_requests:
        "https://gitlab-nht.stackroute.in/api/v4/projects/3011/merge_requests",
      repo_branches:
        "https://gitlab-nht.stackroute.in/api/v4/projects/3011/repository/branches",
      labels: "https://gitlab-nht.stackroute.in/api/v4/projects/3011/labels",
      events: "https://gitlab-nht.stackroute.in/api/v4/projects/3011/events",
      members: "https://gitlab-nht.stackroute.in/api/v4/projects/3011/members"
    },
    archived: false,
    visibility: "internal",
    resolve_outdated_diff_discussions: false,
    container_registry_enabled: true,
    issues_enabled: true,
    merge_requests_enabled: true,
    wiki_enabled: true,
    jobs_enabled: true,
    snippets_enabled: true,
    shared_runners_enabled: true,
    lfs_enabled: true,
    creator_id: 184,
    import_status: "none",
    open_issues_count: 0,
    public_jobs: true,
    ci_config_path: null,
    shared_with_groups: [],
    only_allow_merge_if_pipeline_succeeds: false,
    request_access_enabled: false,
    only_allow_merge_if_all_discussions_are_resolved: false,
    printing_merge_request_link_enabled: true,
    merge_method: "merge",
    permissions: {
      project_access: null,
      group_access: null
    }
  },
  {
    id: 2445,
    description: "",
    name: "collections",
    name_with_namespace: "java_assignment_hyd / collections",
    path: "collections",
    path_with_namespace: "java_assignment_hyd/collections",
    created_at: "2019-07-15T14:44:41.877+05:30",
    default_branch: "master",
    tag_list: [],
    ssh_url_to_repo:
      "git@gitlab-nht.stackroute.in:java_assignment_hyd/collections.git",
    http_url_to_repo:
      "https://gitlab-nht.stackroute.in/java_assignment_hyd/collections.git",
    web_url: "https://gitlab-nht.stackroute.in/java_assignment_hyd/collections",
    readme_url:
      "https://gitlab-nht.stackroute.in/java_assignment_hyd/collections/blob/master/README.md",
    avatar_url: null,
    star_count: 0,
    forks_count: 0,
    last_activity_at: "2019-07-15T14:44:41.877+05:30",
    namespace: {
      id: 310,
      name: "java_assignment_hyd",
      path: "java_assignment_hyd",
      kind: "group",
      full_path: "java_assignment_hyd",
      parent_id: null
    },
    _links: {
      self: "https://gitlab-nht.stackroute.in/api/v4/projects/2445",
      issues: "https://gitlab-nht.stackroute.in/api/v4/projects/2445/issues",
      merge_requests:
        "https://gitlab-nht.stackroute.in/api/v4/projects/2445/merge_requests",
      repo_branches:
        "https://gitlab-nht.stackroute.in/api/v4/projects/2445/repository/branches",
      labels: "https://gitlab-nht.stackroute.in/api/v4/projects/2445/labels",
      events: "https://gitlab-nht.stackroute.in/api/v4/projects/2445/events",
      members: "https://gitlab-nht.stackroute.in/api/v4/projects/2445/members"
    },
    archived: false,
    visibility: "internal",
    resolve_outdated_diff_discussions: false,
    container_registry_enabled: true,
    issues_enabled: true,
    merge_requests_enabled: true,
    wiki_enabled: true,
    jobs_enabled: true,
    snippets_enabled: true,
    shared_runners_enabled: true,
    lfs_enabled: true,
    creator_id: 12,
    import_status: "none",
    open_issues_count: 0,
    public_jobs: true,
    ci_config_path: null,
    shared_with_groups: [],
    only_allow_merge_if_pipeline_succeeds: false,
    request_access_enabled: false,
    only_allow_merge_if_all_discussions_are_resolved: false,
    printing_merge_request_link_enabled: true,
    merge_method: "merge",
    permissions: {
      project_access: null,
      group_access: null
    }
  },
  {
    id: 2442,
    description: "",
    name: "oop",
    name_with_namespace: "java_assignment_hyd / oop",
    path: "oop",
    path_with_namespace: "java_assignment_hyd/oop",
    created_at: "2019-07-15T14:43:01.252+05:30",
    default_branch: "master",
    tag_list: [],
    ssh_url_to_repo: "git@gitlab-nht.stackroute.in:java_assignment_hyd/oop.git",
    http_url_to_repo:
      "https://gitlab-nht.stackroute.in/java_assignment_hyd/oop.git",
    web_url: "https://gitlab-nht.stackroute.in/java_assignment_hyd/oop",
    readme_url:
      "https://gitlab-nht.stackroute.in/java_assignment_hyd/oop/blob/master/README.md",
    avatar_url: null,
    star_count: 0,
    forks_count: 0,
    last_activity_at: "2019-07-16T13:18:31.646+05:30",
    namespace: {
      id: 310,
      name: "java_assignment_hyd",
      path: "java_assignment_hyd",
      kind: "group",
      full_path: "java_assignment_hyd",
      parent_id: null
    },
    _links: {
      self: "https://gitlab-nht.stackroute.in/api/v4/projects/2442",
      issues: "https://gitlab-nht.stackroute.in/api/v4/projects/2442/issues",
      merge_requests:
        "https://gitlab-nht.stackroute.in/api/v4/projects/2442/merge_requests",
      repo_branches:
        "https://gitlab-nht.stackroute.in/api/v4/projects/2442/repository/branches",
      labels: "https://gitlab-nht.stackroute.in/api/v4/projects/2442/labels",
      events: "https://gitlab-nht.stackroute.in/api/v4/projects/2442/events",
      members: "https://gitlab-nht.stackroute.in/api/v4/projects/2442/members"
    },
    archived: false,
    visibility: "internal",
    resolve_outdated_diff_discussions: false,
    container_registry_enabled: true,
    issues_enabled: true,
    merge_requests_enabled: true,
    wiki_enabled: true,
    jobs_enabled: true,
    snippets_enabled: true,
    shared_runners_enabled: true,
    lfs_enabled: true,
    creator_id: 12,
    import_status: "none",
    open_issues_count: 0,
    public_jobs: true,
    ci_config_path: null,
    shared_with_groups: [],
    only_allow_merge_if_pipeline_succeeds: false,
    request_access_enabled: false,
    only_allow_merge_if_all_discussions_are_resolved: false,
    printing_merge_request_link_enabled: true,
    merge_method: "merge",
    permissions: {
      project_access: null,
      group_access: null
    }
  },
  {
    id: 2440,
    description: "",
    name: "string_operations",
    name_with_namespace: "java_assignment_hyd / string_operations",
    path: "string_operations",
    path_with_namespace: "java_assignment_hyd/string_operations",
    created_at: "2019-07-15T14:40:49.182+05:30",
    default_branch: "master",
    tag_list: [],
    ssh_url_to_repo:
      "git@gitlab-nht.stackroute.in:java_assignment_hyd/string_operations.git",
    http_url_to_repo:
      "https://gitlab-nht.stackroute.in/java_assignment_hyd/string_operations.git",
    web_url:
      "https://gitlab-nht.stackroute.in/java_assignment_hyd/string_operations",
    readme_url:
      "https://gitlab-nht.stackroute.in/java_assignment_hyd/string_operations/blob/master/README.md",
    avatar_url: null,
    star_count: 0,
    forks_count: 0,
    last_activity_at: "2019-07-15T14:40:49.182+05:30",
    namespace: {
      id: 310,
      name: "java_assignment_hyd",
      path: "java_assignment_hyd",
      kind: "group",
      full_path: "java_assignment_hyd",
      parent_id: null
    },
    _links: {
      self: "https://gitlab-nht.stackroute.in/api/v4/projects/2440",
      issues: "https://gitlab-nht.stackroute.in/api/v4/projects/2440/issues",
      merge_requests:
        "https://gitlab-nht.stackroute.in/api/v4/projects/2440/merge_requests",
      repo_branches:
        "https://gitlab-nht.stackroute.in/api/v4/projects/2440/repository/branches",
      labels: "https://gitlab-nht.stackroute.in/api/v4/projects/2440/labels",
      events: "https://gitlab-nht.stackroute.in/api/v4/projects/2440/events",
      members: "https://gitlab-nht.stackroute.in/api/v4/projects/2440/members"
    },
    archived: false,
    visibility: "internal",
    resolve_outdated_diff_discussions: false,
    container_registry_enabled: true,
    issues_enabled: true,
    merge_requests_enabled: true,
    wiki_enabled: true,
    jobs_enabled: true,
    snippets_enabled: true,
    shared_runners_enabled: true,
    lfs_enabled: true,
    creator_id: 12,
    import_status: "none",
    open_issues_count: 0,
    public_jobs: true,
    ci_config_path: null,
    shared_with_groups: [],
    only_allow_merge_if_pipeline_succeeds: false,
    request_access_enabled: false,
    only_allow_merge_if_all_discussions_are_resolved: false,
    printing_merge_request_link_enabled: true,
    merge_method: "merge",
    permissions: {
      project_access: null,
      group_access: null
    }
  },
  {
    id: 2439,
    description: "",
    name: "patterns",
    name_with_namespace: "java_assignment_hyd / patterns",
    path: "patterns",
    path_with_namespace: "java_assignment_hyd/patterns",
    created_at: "2019-07-15T14:39:36.821+05:30",
    default_branch: "master",
    tag_list: [],
    ssh_url_to_repo:
      "git@gitlab-nht.stackroute.in:java_assignment_hyd/patterns.git",
    http_url_to_repo:
      "https://gitlab-nht.stackroute.in/java_assignment_hyd/patterns.git",
    web_url: "https://gitlab-nht.stackroute.in/java_assignment_hyd/patterns",
    readme_url:
      "https://gitlab-nht.stackroute.in/java_assignment_hyd/patterns/blob/master/README.md",
    avatar_url: null,
    star_count: 0,
    forks_count: 0,
    last_activity_at: "2019-07-16T13:05:04.117+05:30",
    namespace: {
      id: 310,
      name: "java_assignment_hyd",
      path: "java_assignment_hyd",
      kind: "group",
      full_path: "java_assignment_hyd",
      parent_id: null
    },
    _links: {
      self: "https://gitlab-nht.stackroute.in/api/v4/projects/2439",
      issues: "https://gitlab-nht.stackroute.in/api/v4/projects/2439/issues",
      merge_requests:
        "https://gitlab-nht.stackroute.in/api/v4/projects/2439/merge_requests",
      repo_branches:
        "https://gitlab-nht.stackroute.in/api/v4/projects/2439/repository/branches",
      labels: "https://gitlab-nht.stackroute.in/api/v4/projects/2439/labels",
      events: "https://gitlab-nht.stackroute.in/api/v4/projects/2439/events",
      members: "https://gitlab-nht.stackroute.in/api/v4/projects/2439/members"
    },
    archived: false,
    visibility: "internal",
    resolve_outdated_diff_discussions: false,
    container_registry_enabled: true,
    issues_enabled: true,
    merge_requests_enabled: true,
    wiki_enabled: true,
    jobs_enabled: true,
    snippets_enabled: true,
    shared_runners_enabled: true,
    lfs_enabled: true,
    creator_id: 12,
    import_status: "none",
    open_issues_count: 0,
    public_jobs: true,
    ci_config_path: null,
    shared_with_groups: [],
    only_allow_merge_if_pipeline_succeeds: false,
    request_access_enabled: false,
    only_allow_merge_if_all_discussions_are_resolved: false,
    printing_merge_request_link_enabled: true,
    merge_method: "merge",
    permissions: {
      project_access: null,
      group_access: null
    }
  },
  {
    id: 2437,
    description: "",
    name: "General-programming-logic",
    name_with_namespace: "java_assignment_hyd / General-programming-logic",
    path: "general-programming-logic",
    path_with_namespace: "java_assignment_hyd/general-programming-logic",
    created_at: "2019-07-15T14:32:05.017+05:30",
    default_branch: "master",
    tag_list: [],
    ssh_url_to_repo:
      "git@gitlab-nht.stackroute.in:java_assignment_hyd/general-programming-logic.git",
    http_url_to_repo:
      "https://gitlab-nht.stackroute.in/java_assignment_hyd/general-programming-logic.git",
    web_url:
      "https://gitlab-nht.stackroute.in/java_assignment_hyd/general-programming-logic",
    readme_url:
      "https://gitlab-nht.stackroute.in/java_assignment_hyd/general-programming-logic/blob/master/README.md",
    avatar_url: null,
    star_count: 0,
    forks_count: 0,
    last_activity_at: "2019-07-16T10:04:59.722+05:30",
    namespace: {
      id: 310,
      name: "java_assignment_hyd",
      path: "java_assignment_hyd",
      kind: "group",
      full_path: "java_assignment_hyd",
      parent_id: null
    },
    _links: {
      self: "https://gitlab-nht.stackroute.in/api/v4/projects/2437",
      issues: "https://gitlab-nht.stackroute.in/api/v4/projects/2437/issues",
      merge_requests:
        "https://gitlab-nht.stackroute.in/api/v4/projects/2437/merge_requests",
      repo_branches:
        "https://gitlab-nht.stackroute.in/api/v4/projects/2437/repository/branches",
      labels: "https://gitlab-nht.stackroute.in/api/v4/projects/2437/labels",
      events: "https://gitlab-nht.stackroute.in/api/v4/projects/2437/events",
      members: "https://gitlab-nht.stackroute.in/api/v4/projects/2437/members"
    },
    archived: false,
    visibility: "internal",
    resolve_outdated_diff_discussions: false,
    container_registry_enabled: true,
    issues_enabled: true,
    merge_requests_enabled: true,
    wiki_enabled: true,
    jobs_enabled: true,
    snippets_enabled: true,
    shared_runners_enabled: true,
    lfs_enabled: true,
    creator_id: 12,
    import_status: "none",
    open_issues_count: 0,
    public_jobs: true,
    ci_config_path: null,
    shared_with_groups: [],
    only_allow_merge_if_pipeline_succeeds: false,
    request_access_enabled: false,
    only_allow_merge_if_all_discussions_are_resolved: false,
    printing_merge_request_link_enabled: true,
    merge_method: "merge",
    permissions: {
      project_access: null,
      group_access: null
    }
  }
];

describe("Testing fecth API Operation", () => {
    afterEach(fetchmock.restore);
    it("Should make a call to gitlab api url", done => {
    fetchmock.get(
      "https://gitlab-nht.stackroute.in/api/v4/projects?private_token=8S5s5mxWsHv4c1Dh5Zpv",
      mockdata
    );
    fetchapi().then(data => {
      expect(fetchmock.done()).to.equals(true);
    }).catch();
    done();
  });
  it("Should make a call to specific gitlab uri", done => {
    fetchmock.get(
      "https://gitlab-nht.stackroute.in/api/v4/projects?private_token=8S5s5mxWsHv4c1Dh5Zpv",
      mockdata
    );
    fetchapi().then(data => {
      expect(fetchmock.lastUrl).to.contain(
        "https://gitlab-nht.stackroute.in/api/v4/projects?private_token=8S5s5mxWsHv4c1Dh5Zpv"
      );
    }).catch();
    done();
  });
});
